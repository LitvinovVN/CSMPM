using CSMPMWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMPMWeb.Controllers
{
    public class SystemModulesController : Controller
    {
        ISystemModuleRepository _systemModuleRepository;

        public SystemModulesController(ISystemModuleRepository systemModuleRepository)
        {
            _systemModuleRepository = systemModuleRepository;
        }

        public async Task<IActionResult> Index()
        {
            var systemModules = await _systemModuleRepository.GetSystemModulesAsync();

            return View(systemModules);
        }

        public async Task<IActionResult> Edit(int id)
        {
            SystemModule systemModule;

            if (id == 0)
                systemModule = new SystemModule();
            else
                systemModule = await _systemModuleRepository.GetSystemModuleAsync(id);

            if (systemModule == null) return NotFound();

            return View(systemModule);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SystemModule systemModule)
        {
            await _systemModuleRepository.UpdateSystemModuleAsync(systemModule);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var systemModule = await _systemModuleRepository.GetSystemModuleAsync(id);

            if (systemModule == null) return NotFound();

            return View(systemModule);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(SystemModule systemModule)
        {
            await _systemModuleRepository.RemoveSystemModuleAsync(systemModule);

            return RedirectToAction(nameof(Index));
        }
    }
}
