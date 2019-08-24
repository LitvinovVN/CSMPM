using CSMPMWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CSMPMWeb.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        private AppUserRepository _appUserRepository;

        public AccountController(UserManager<AppUser> userMgr,
            SignInManager<AppUser> signInMagr,
            AppUserRepository appUserRepository)
        {
            userManager = userMgr;
            signInManager = signInMagr;
            _appUserRepository = appUserRepository;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel details, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByEmailAsync(details.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, details.Password, false, false);

                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(LoginModel.Email), "Неверные учетные данные");
            }

            return View(details);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }


        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        /// <summary>
        /// Выбор активным пользователем текущей организации
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> SelectCurrentOrganization(int id)
        {
            if(id != 0)
            {
                await _appUserRepository.SelectCurrentOrganizationAsync(User.Identity.Name, id);
            }
            var appUserToOrganizations = await _appUserRepository.GetAppUserToOrganizationsAsync(User.Identity.Name);
            return View(appUserToOrganizations);
        }
    }
}
