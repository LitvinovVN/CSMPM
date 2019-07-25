using CSMPMLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMPMWeb.Controllers
{    
    //[Authorize]
    public class CropsController : Controller
    {
        ICropRepository _cropRepository;
        ICropGroupRepository _cropGroupRepository;

        public CropsController(ICropRepository cropRepository,
            ICropGroupRepository cropGroupRepository)
        {
            _cropRepository = cropRepository;
            _cropGroupRepository = cropGroupRepository;
        }

        public async Task<IActionResult> Index()
        {
            var crops = await _cropRepository.GetCropsAsync();
            return View(crops);
        }


        public async Task<IActionResult> Edit(int id)
        {
            Crop crop;
            if (id == 0)
                crop = new Crop();
            else
                crop = await _cropRepository.GetCropAsync(id);

            if (crop == null) return NotFound();

            ViewBag.CropGroups = new SelectList(await _cropGroupRepository.GetCropGroupsAsync(),
                nameof(CropGroup.CropGroupId),
                nameof(CropGroup.CropGroupName),
                crop.CropGroupId);

            return View(crop);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Crop crop)
        {
            if (crop == null) return NotFound();
            await _cropRepository.UpdateCropAsync(crop);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            var crop = await _cropRepository.GetCropAsync(id);
            if (crop == null) return NotFound();

            return View(crop);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Crop crop)
        {
            if (crop == null) return NotFound();
            await _cropRepository.RemoveCropAsync(crop);

            return RedirectToAction(nameof(Index));
        }
    }
}
