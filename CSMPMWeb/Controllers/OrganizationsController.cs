using CSMPMLib;
using CSMPMWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMPMWeb.Controllers
{
    public class OrganizationsController : Controller
    {
        IOrganizationRepository _organizationRepository;        
        SelectListRepository _selectListRepository;
        ISystemModuleRepository _systemModuleRepository;
        AppUserRepository _appUserRepository;

        public OrganizationsController(IOrganizationRepository organizationRepository,
            SelectListRepository selectListRepository,
            ISystemModuleRepository systemModuleRepositoryEf,
            AppUserRepository appUserRepository)
        {
            _organizationRepository = organizationRepository;
            _selectListRepository = selectListRepository;
            _systemModuleRepository = systemModuleRepositoryEf;
            _appUserRepository = appUserRepository;
        }

        public async Task<IActionResult> Index()
        {
            var organizations = await _organizationRepository.GetOrganizationsAsync();
           
            return View(organizations);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var organization = await _organizationRepository.GetOrganizationAsync(id);
            ViewBag.SelectListOrganizations = await _selectListRepository.GetSelectListOrganizationsAsync(organization?.ParentOrganizationId ?? 0);

            return View(organization);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Organization organization)
        {
            await _organizationRepository.UpdateOrganizationAsync(organization);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var organization = await _organizationRepository.GetOrganizationAsync(id);
            return View(organization);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Organization organization)
        {
             await _organizationRepository.RemoveOrganizationAsync(organization);
            return RedirectToAction(nameof(Index));
        }

        #region Модули системы, доступные организациям
        public async Task<IActionResult> SystemModules(int id)
        {
            var orgModules = await _systemModuleRepository.GetOrganizationToSystemModulesAsync(id);

            ViewBag.Organization = await _organizationRepository.GetOrganizationAsync(id);
            return View(orgModules);
        }

        public async Task<IActionResult> BindModule(int id)
        {
            var model = new OrganizationToSystemModule { OrganizationId = id };
            ViewBag.SystemModules = await _selectListRepository.GetSelectListSystemModulesAsync();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BindModule(OrganizationToSystemModule organizationToSystemModule)
        {
            await _systemModuleRepository.BindSystemModuleToOrganizationAsync(organizationToSystemModule.SystemModuleId, organizationToSystemModule.OrganizationId);
            return RedirectToAction(nameof(SystemModules), new { id = organizationToSystemModule.OrganizationId });
        }

        public async Task<IActionResult> UnbindModule(int id, int systemModuleId)
        {
            var model = await _systemModuleRepository.GetOrganizationToSystemModuleAsync(systemModuleId, id);
            if (model == null)
                return RedirectToAction(nameof(SystemModules), new { id });
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UnbindModule(OrganizationToSystemModule organizationToSystemModule)
        {
            await _systemModuleRepository.UnbindSystemModuleFromOrganizationAsync(organizationToSystemModule.SystemModuleId, organizationToSystemModule.OrganizationId);
            return RedirectToAction(nameof(SystemModules), new { id = organizationToSystemModule.OrganizationId });
        }
        #endregion

        #region Пользователи
        public async Task<IActionResult> AppUsers(int id)
        {
            var usersOfOrganization = await _appUserRepository.GetAppUserToOrganizationsAsync(id);
            ViewBag.Organization = await _organizationRepository.GetOrganizationAsync(id);
            return View(usersOfOrganization);
        }

        public async Task<IActionResult> AppUserAssignedPermissions(int appUserToOrganizationId)
        {
            var model = await _appUserRepository
                .GetAppUserToOrganizationAsync(appUserToOrganizationId);
            return View(model);
        }

        public async Task<IActionResult> AppUserAssignedPermissionCreate(int appUserToOrganizationId)
        {
            var appUserToOrganization = await _appUserRepository
                .GetAppUserToOrganizationAsync(appUserToOrganizationId);
            var assignedPermission = new AssignedPermission
            {
                AppUserToOrganization = appUserToOrganization,
                AppUserToOrganizationId = appUserToOrganizationId
            };

            ViewBag.OrganizationToSystemModules = await _selectListRepository
                .GetSelectListOrganizationToSystemModulesAsync(appUserToOrganization.OrganizationId);
            ViewBag.SystemRoles = await _selectListRepository
                .GetSelectListSystemRolesAsync();
            return View(assignedPermission);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AppUserAssignedPermissionCreate(AssignedPermission assignedPermission)
        {
            await _appUserRepository.AddAssignedPermission(assignedPermission);
            return RedirectToAction(nameof(AppUserAssignedPermissions), new { appUserToOrganizationId = assignedPermission.AppUserToOrganizationId });
        }


        public async Task<IActionResult> AppUserAssignedPermissionEdit(int assignedPermissionId)
        {
            var assignedPermission = await _appUserRepository
                .GetAssignedPermissionAsync(assignedPermissionId);            
            
            ViewBag.SystemRoles = await _selectListRepository
                .GetSelectListSystemRolesAsync();
            return View(assignedPermission);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AppUserAssignedPermissionEdit(AssignedPermission assignedPermission)
        {
            await _appUserRepository.UpdateAssignedPermission(assignedPermission);
            return RedirectToAction(nameof(AppUserAssignedPermissions), new { appUserToOrganizationId = assignedPermission.AppUserToOrganizationId });

        }


        public async Task<IActionResult> AppUserAssignedPermissionDelete(int assignedPermissionId)
        {
            var assignedPermission = await _appUserRepository
                .GetAssignedPermissionAsync(assignedPermissionId);
            
            return View(assignedPermission);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AppUserAssignedPermissionDelete(AssignedPermission assignedPermission)
        {
            await _appUserRepository.RemoveAssignedPermission(assignedPermission);
            return RedirectToAction(nameof(AppUserAssignedPermissions), new { appUserToOrganizationId = assignedPermission.AppUserToOrganizationId });
        }



        public async Task<IActionResult> AppUserToOrganizations(int appUserToOrganizationId)
        {
            var appUserToOrganization = await _appUserRepository
               .GetAppUserToOrganizationAsync(appUserToOrganizationId);

            var appUserToOrganizations = await _appUserRepository.GetAppUserToOrganizationsAsync(appUserToOrganization.AppUser.UserName);

            ViewBag.AppUserToOrganization = appUserToOrganization;
            return View(appUserToOrganizations);
        }

        
        public async Task<IActionResult> BindAppUserToOrganizationBindExistingAppUser(int id)
        {
            var organization = await _organizationRepository.GetOrganizationAsync(id);
            var appUserToOrganization = new AppUserToOrganization
            {
                OrganizationId = id,
                Organization = organization
            };

            ViewBag.AppUsers = await _selectListRepository.GetSelectListAppUsersAsync();

            return View(appUserToOrganization);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BindAppUserToOrganizationBindExistingAppUser(AppUserToOrganization appUserToOrganization)
        {
            await _appUserRepository.BindAppUserToOrganization(appUserToOrganization.AppUserId, appUserToOrganization.OrganizationId);

            return RedirectToAction(nameof(AppUsers), new { id = appUserToOrganization.OrganizationId });
        }

        public async Task<IActionResult> BindAppUserToOrganization(int appUserToOrganizationId)
        {
            var appUserToOrganization = await _appUserRepository
               .GetAppUserToOrganizationAsync(appUserToOrganizationId);

            ViewBag.Organizations = await _selectListRepository.GetSelectListOrganizationsAsync();

            return View(appUserToOrganization);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BindAppUserToOrganization(AppUserToOrganization appUserToOrganization)
        {
            await _appUserRepository.BindAppUserToOrganization(appUserToOrganization.AppUserId, appUserToOrganization.OrganizationId);           

            return RedirectToAction(nameof(AppUserToOrganizations), new { appUserToOrganization.AppUserToOrganizationId });
        }

        public async Task<IActionResult> UnbindAppUserToOrganization(int appUserToOrganizationId, int appUserToOrganizationToRedirectId)
        {
            var appUserToOrganization = await _appUserRepository
               .GetAppUserToOrganizationAsync(appUserToOrganizationId);

            ViewBag.appUserToOrganizationToRedirectId = appUserToOrganizationToRedirectId;
            return View(appUserToOrganization);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UnbindAppUserToOrganization(AppUserToOrganization appUserToOrganization, int appUserToOrganizationToRedirectId)
        {
            await _appUserRepository.UnbindAppUserToOrganization(appUserToOrganization);

            if(appUserToOrganization.AppUserToOrganizationId != appUserToOrganizationToRedirectId)
            {
                return RedirectToAction(nameof(AppUserToOrganizations), new { appUserToOrganizationId = appUserToOrganizationToRedirectId });
            }
            else
            {
                return RedirectToAction(nameof(AppUsers), new { id = appUserToOrganization.OrganizationId });
            }
            
        }
        #endregion
    }
}
