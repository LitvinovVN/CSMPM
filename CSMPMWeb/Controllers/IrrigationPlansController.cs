using CSMPMLib;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMPMWeb.Controllers
{
    public class IrrigationPlansController : Controller
    {
        IIrrigationPlanRepository _irrigationPlanRepository;
        public IrrigationPlansController(IIrrigationPlanRepository irrigationPlanRepository)
        {
            _irrigationPlanRepository = irrigationPlanRepository;
        }

        public async Task<IActionResult> Index()
        {
            var irrigationPlans = await _irrigationPlanRepository.GetIrrigationPlansAsync();
            return View(irrigationPlans);
        }
    }
}
