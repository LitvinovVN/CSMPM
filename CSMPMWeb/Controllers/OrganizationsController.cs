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
            var model = await _appUserRepository.GetAppUserToOrganizationAsync(appUserToOrganizationId);
            return View(model);
        }
        #endregion
    }
}
