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
    }
}
