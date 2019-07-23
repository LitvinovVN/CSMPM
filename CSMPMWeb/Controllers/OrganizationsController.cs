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

        public OrganizationsController(IOrganizationRepository organizationRepository,
            SelectListRepository selectListRepository)
        {
            _organizationRepository = organizationRepository;
            _selectListRepository = selectListRepository;
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
    }
}
