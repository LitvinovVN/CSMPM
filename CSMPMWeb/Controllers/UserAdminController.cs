using CSMPMWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMPMWeb.Controllers
{
    /// <summary>
    /// Контроллер управления учётными записями пользователей
    /// </summary>
    //[Authorize(Roles = "Administrators")]
    public class UserAdminController : Controller
    {
        #region Закрытые поля
        private UserManager<AppUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private IUserValidator<AppUser> _userValidator;
        private IPasswordValidator<AppUser> _passwordValidator;
        private IPasswordHasher<AppUser> _passwordHasher;
        private MySqlDbContext context;
        #endregion

        #region Конструктор
        public UserAdminController(UserManager<AppUser> usrMgr,
            RoleManager<IdentityRole> roleMgr,
            IUserValidator<AppUser> userValid,
            IPasswordValidator<AppUser> passValid,
            IPasswordHasher<AppUser> passwordHash,
            MySqlDbContext ctx)
        {
            _userManager = usrMgr;
            _roleManager = roleMgr;
            _userValidator = userValid;
            _passwordValidator = passValid;
            _passwordHasher = passwordHash;
            context = ctx;
        }
        #endregion

        #region Index
        public ViewResult Index()
        {
            var users = context.Users;
            return View(users);
        }
        #endregion

        #region Create
        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(AppUserCreateModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Patronymic = model.Patronymic,
                    UserName = model.Name,
                    Email = model.Email
                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
        #endregion

        #region Delete
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    AddErrorsFromResult(result);
            }
            else
            {
                ModelState.AddModelError("", "Пользователь не найден");
            }

            return View("Index", _userManager.Users);
        }
        #endregion

        #region Edit
        public async Task<IActionResult> Edit(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
                return View(user);
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AppUser userDataFromView, string password)
        {
            AppUser user = await _userManager.FindByIdAsync(userDataFromView.Id);
            if (user != null)
            {
                user.FirstName = userDataFromView.FirstName;
                user.LastName = userDataFromView.LastName;
                user.Patronymic = userDataFromView.Patronymic;

                user.Email = userDataFromView.Email;
                IdentityResult validEmail = await _userValidator.ValidateAsync(_userManager, user);
                if (!validEmail.Succeeded)
                {
                    AddErrorsFromResult(validEmail);
                }

                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(password))
                {
                    validPass = await _passwordValidator.ValidateAsync(_userManager, user, password);
                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user, password);
                    }
                    else
                    {
                        AddErrorsFromResult(validPass);
                    }
                }

                if ((validEmail.Succeeded && validPass == null) || (validEmail.Succeeded && password != string.Empty && validPass.Succeeded))
                {
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Пользователь не найден");
            }

            return View(user);
        }
        #endregion

        #region Редактирование ролей пользователя
        /// <summary>
        /// Редактирование ролей пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> EditUserRoles(string id)
        {
            var appUser = await _userManager.FindByIdAsync(id);
            var roles = _roleManager.Roles.ToList();            
            var userRoles = await _userManager.GetRolesAsync(appUser);
            var viewModel = new AppUserEditRolesViewModel(appUser, roles, userRoles);
            
            return View(viewModel); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUserRoles(AppUserEditRolesViewModel viewModel)
        {
            var appUser = await _userManager.FindByIdAsync(viewModel.AppUser.Id);

            foreach(var role in viewModel.Roles)
            {
                if (role.IsInRole == role.IsInRole_Edited) continue;

                if(role.IsInRole_Edited)
                {
                    await _userManager.AddToRoleAsync(appUser, role.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(appUser, role.RoleName);
                }
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Вспомогательные методы
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        #endregion
    }
}
