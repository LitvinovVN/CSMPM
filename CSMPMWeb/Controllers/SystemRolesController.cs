using CSMPMWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMPMWeb.Controllers
{
    public class SystemRolesController : Controller
    {
        ISystemRoleRepository _systemRoleRepository;

        public SystemRolesController(ISystemRoleRepository systemRoleRepository)
        {
            _systemRoleRepository = systemRoleRepository;
        }

        public async Task<IActionResult> Index()
        {
            var systemRoles = await _systemRoleRepository.GetSystemRolesAsync();

            return View(systemRoles);
        }

        public async Task<IActionResult> Edit(int id)
        {
            SystemRole systemRole;

            if (id == 0)
                systemRole = new SystemRole();
            else
                systemRole = await _systemRoleRepository.GetSystemRoleAsync(id);

            if (systemRole == null) return NotFound();

            return View(systemRole);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SystemRole systemRole)
        {
            await _systemRoleRepository.UpdateSystemRoleAsync(systemRole);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            SystemRole systemRole = await _systemRoleRepository.GetSystemRoleAsync(id);

            if (systemRole == null) return NotFound();

            return View(systemRole);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(SystemRole systemRole)
        {
            await _systemRoleRepository.RemoveSystemRoleAsync(systemRole);

            return RedirectToAction(nameof(Index));
        }
    }
}
