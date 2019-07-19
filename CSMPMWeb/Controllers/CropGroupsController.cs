using CSMPMLib;
using Microsoft.AspNetCore.Mvc;

namespace CSMPMWeb.Controllers
{
    public class CropGroupsController : Controller
    {
        ICropGroupRepository _cropGroupRepository;

        public CropGroupsController(ICropGroupRepository cropGroupRepository)
        {
            _cropGroupRepository = cropGroupRepository;
        }

        public IActionResult Index()
        {
            var cropGroups = _cropGroupRepository.GetCropGroupsAsync();
            return View(cropGroups);
        }
    }
}
