using CSMPMLib;
using CSMPMWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMPMWeb.Controllers
{
    public class IrrigationSystemsController : Controller
    {
        IIrrigationSystemRepository _irrigationSystemRepository;
        IOrganizationRepository _organizationRepository;
        SelectListRepository _selectListRepository;

        public IrrigationSystemsController(IIrrigationSystemRepository irrigationSystemRepository,
            SelectListRepository selectListRepository,
            IOrganizationRepository organizationRepository)
        {
            _irrigationSystemRepository = irrigationSystemRepository;
            _selectListRepository = selectListRepository;
            _organizationRepository = organizationRepository;
        }

        public async Task<IActionResult> Index()
        {
            var irrigationSystems = await _irrigationSystemRepository.GetIrrigationSystemsAsync();
            return View(irrigationSystems);
        }

        public async Task<IActionResult> Organizations(int id)
        {
            var org = await _irrigationSystemRepository.GetIrrigationSystemAsync(id);
            return View(org);
        }

        public async Task<IActionResult> OrganizationsCreate(int irrigationSystemId, int organizationId)
        {
            var model = new OrganizationToTypeOfActivitiesToIrrigationSystem { IrrigationSystemId = irrigationSystemId };
            model.IrrigationSystem = await _irrigationSystemRepository.GetIrrigationSystemAsync(irrigationSystemId);

            ViewBag.Organizations = await _selectListRepository.GetSelectListOrganizationsAsync();
            ViewBag.TypeOfActivities = await _selectListRepository.GetSelectListTypeOfActivitiesMeliorationAsync();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrganizationsCreate(OrganizationToTypeOfActivitiesToIrrigationSystem model)
        {
            int organizationId = model.OrganizationToTypeOfActivity.OrganizationId;
            int typeOfActivityId = model.OrganizationToTypeOfActivity.TypeOfActivityId;
            int irrigationSystemId = model.IrrigationSystemId;
            await _irrigationSystemRepository.AddTypeOfActivityOfOrganizationForIrrigationSystemAsync(organizationId, typeOfActivityId, irrigationSystemId);

            return RedirectToAction(nameof(Organizations), new { id = model.IrrigationSystemId });
        }

        public async Task<IActionResult> OrganizationsEdit(int organizationToTypeOfActivitiesToIrrigationSystemId)
        {
            var model = await _irrigationSystemRepository.GetOrganizationToTypeOfActivitiesToIrrigationSystemAsync(organizationToTypeOfActivitiesToIrrigationSystemId);
                        
            ViewBag.TypeOfActivities = await _selectListRepository.GetSelectListTypeOfActivitiesMeliorationAsync();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrganizationsEdit(OrganizationToTypeOfActivitiesToIrrigationSystem model)
        {
            int organizationId = model.OrganizationToTypeOfActivity.OrganizationId;
            int typeOfActivityId = model.OrganizationToTypeOfActivity.TypeOfActivityId;
            int irrigationSystemId = model.IrrigationSystemId;
            await _irrigationSystemRepository.ChangeTypeOfActivityOfOrganizationForIrrigationSystemAsync(organizationId, typeOfActivityId, irrigationSystemId);
            
            return RedirectToAction(nameof(Organizations), new { id = model.IrrigationSystemId });
        }

        public async Task<IActionResult> OrganizationsDelete(int organizationToTypeOfActivitiesToIrrigationSystemId)
        {
            var model = await _irrigationSystemRepository.GetOrganizationToTypeOfActivitiesToIrrigationSystemAsync(organizationToTypeOfActivitiesToIrrigationSystemId);
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrganizationsDeleteConfirmed(int id)
        {
            var model = await _irrigationSystemRepository.GetOrganizationToTypeOfActivitiesToIrrigationSystemAsync(id);
            await _irrigationSystemRepository.RemoveOrganizationToTypeOfActivitiesToIrrigationSystemAsync(model);

            return RedirectToAction(nameof(Organizations), new { id = model.IrrigationSystemId });
        }
    }
}
