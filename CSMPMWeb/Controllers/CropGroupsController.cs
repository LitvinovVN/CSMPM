using CSMPMLib;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CSMPMWeb.Controllers
{
    public class CropGroupsController : Controller
    {
        ICropGroupRepository _cropGroupRepository;

        public CropGroupsController(ICropGroupRepository cropGroupRepository)
        {
            _cropGroupRepository = cropGroupRepository;
        }

        public async Task<IActionResult> Index()
        {
            var cropGroups = await _cropGroupRepository.GetCropGroupsAsync();
            return View(cropGroups);
        }

        public async Task<IActionResult> Edit(int id)
        {
            CropGroup cropGroup;

            if(id == 0)
            {
                cropGroup = new CropGroup();
            }
            else
            {
                cropGroup = await _cropGroupRepository.GetCropGroupAsync(id);
                if (cropGroup == null)
                    return RedirectToAction(nameof(Index));
            }

            return View(cropGroup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CropGroup cropGroup)
        {
            if (cropGroup == null)
                return RedirectToAction(nameof(Index));
            if(cropGroup.CropGroupId == 0)
            {
                await _cropGroupRepository.AddCropGroupAsync(cropGroup);                
            }
            else
            {
                await _cropGroupRepository.UpdateCropGroupAsync(cropGroup);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cropGroup = await _cropGroupRepository.GetCropGroupAsync(id);
            return View(cropGroup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(CropGroup cropGroup)
        {
            await _cropGroupRepository.RemoveCropGroupAsync(cropGroup);            
            return RedirectToAction(nameof(Index));
        }
    }
}
