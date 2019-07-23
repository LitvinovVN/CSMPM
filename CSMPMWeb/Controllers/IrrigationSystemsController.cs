using CSMPMLib;
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
        public IrrigationSystemsController(IIrrigationSystemRepository irrigationSystemRepository)
        {
            _irrigationSystemRepository = irrigationSystemRepository;
        }

        public async Task<IActionResult> Index()
        {
            var irrgationSystems = await _irrigationSystemRepository.GetIrrigationSystemsAsync();
            return View(irrgationSystems);
        }
    }
}
