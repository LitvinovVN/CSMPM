using CSMPMLib;
using CSMPMWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMPMWeb.Controllers
{
    public class IrrigationPlansUserController : Controller
    {
        IIrrigationPlanRepository _irrigationPlanRepository;
        SelectListRepository _selectListRepository;
        public IrrigationPlansUserController(IIrrigationPlanRepository irrigationPlanRepository,
            SelectListRepository selectListRepository)
        {
            _irrigationPlanRepository = irrigationPlanRepository;
            _selectListRepository = selectListRepository;
        }

        #region Перечень планов водопотребления        
        public async Task<IActionResult> Index()
        {            
            var irrigationPlans = await _irrigationPlanRepository.GetIrrigationPlansOfCurrentOrganizationAsync(User.Identity.Name);
            return View(irrigationPlans);
        }                

        public async Task<IActionResult> Edit(int id)
        {
            IrrigationPlan irrigationPlan;

            if (id == 0)
            {
                irrigationPlan = new IrrigationPlan { Year = DateTime.Now.Year };
            }
            else
            {
                irrigationPlan = await _irrigationPlanRepository.GetIrrigationPlanAsync(id, User.Identity.Name);
            }

            ViewBag.OrganizationDocumentationPlans = await _selectListRepository.GetSelectListCurrentOrganizationDocumentationPlansAsync(User.Identity.Name, irrigationPlan.OrganizationDocumentationPlansId);

            return View(irrigationPlan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IrrigationPlan irrigationPlan)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.OrganizationDocumentationPlans = await _selectListRepository.GetSelectListOrganizationDocumentationPlansAsync(User.Identity.Name, irrigationPlan.OrganizationDocumentationPlansId);
                return View(irrigationPlan);
            }                

            if(irrigationPlan.IrrigationPlanId == 0)
            {
                await _irrigationPlanRepository.AddIrrigationPlanAsync(irrigationPlan, User.Identity.Name);
            }
            else
            {
                await _irrigationPlanRepository.UpdateIrrigationPlanAsync(irrigationPlan, User.Identity.Name);
            }
                        
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var irrigationPlan = await _irrigationPlanRepository.GetIrrigationPlanAsync(id, User.Identity.Name);

            if (irrigationPlan == null) return NotFound();

            return View(irrigationPlan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(IrrigationPlan irrigationPlan)
        {
            await _irrigationPlanRepository.RemoveIrrigationPlanAsync(irrigationPlan);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Содержимое плана
        public async Task<IActionResult> IrrigationPlanItems(int irrigationPlanId)
        {
            var irrigationPlan = await _irrigationPlanRepository.GetIrrigationPlanAsync(irrigationPlanId, User.Identity.Name);

            return View(irrigationPlan);
        }

        public async Task<IActionResult> IrrigationPlanItemCreate(int irrigationPlanId)
        {
            var irrigationPlan = await _irrigationPlanRepository.GetIrrigationPlanAsync(irrigationPlanId, User.Identity.Name);

            var irrigationPlanItem = new IrrigationPlanItem
            {
                IrrigationPlan = irrigationPlan,
                IrrigationPlanId = irrigationPlanId
            };

            ViewBag.IrrigationSystems = await _selectListRepository.GetSelectListIrrigationSystemsAsync(User.Identity.Name);
            return View(nameof(IrrigationPlanItemEdit), irrigationPlanItem);
        }

        public async Task<IActionResult> IrrigationPlanItemEdit(int id)
        {
            var irrigationPlanItem = await _irrigationPlanRepository.GetIrrigationPlanItemAsync(id);

            ViewBag.IrrigationSystems = await _selectListRepository.GetSelectListIrrigationSystemsAsync(User.Identity.Name);
            return View(irrigationPlanItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IrrigationPlanItemEdit(IrrigationPlanItem irrigationPlanItem)
        {
            if (!ModelState.IsValid)
            {
                var irrigationPlan = await _irrigationPlanRepository.GetIrrigationPlanAsync(irrigationPlanItem.IrrigationPlanId);
                irrigationPlanItem.IrrigationPlan = irrigationPlan;
                ViewBag.IrrigationSystems = await _selectListRepository.GetSelectListIrrigationSystemsAsync(User.Identity.Name);
                return View(irrigationPlanItem);
            }

            await _irrigationPlanRepository.UpdateIrrigationPlanItemAsync(irrigationPlanItem);
            return RedirectToAction(nameof(IrrigationPlanItems), new { irrigationPlanItem.IrrigationPlanId });
        }

        public async Task<IActionResult> IrrigationPlanItemDelete(int id)
        {
            var irrigationPlanItem = await _irrigationPlanRepository.GetIrrigationPlanItemAsync(id);
            return View(irrigationPlanItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IrrigationPlanItemDeleteConfirmed(IrrigationPlanItem irrigationPlanItem)
        {
            await _irrigationPlanRepository.RemoveIrrigationPlanItemAsync(irrigationPlanItem);
            return RedirectToAction(nameof(IrrigationPlanItems), new { irrigationPlanItem.IrrigationPlanId });
        }
        #endregion

        #region Посев, полив
        public async Task<IActionResult> CropSowingAndIrrigations(int irrigationPlanItemId)
        {
            var irrigationPlanItem = await _irrigationPlanRepository.GetIrrigationPlanItemAsync(irrigationPlanItemId);

            return View(irrigationPlanItem);
        }

        public async Task<IActionResult> CropSowingAndIrrigationCreate(int irrigationPlanItemId)
        {
            var irrigationPlanItem = await _irrigationPlanRepository.GetIrrigationPlanItemAsync(irrigationPlanItemId);

            if (irrigationPlanItem == null) return NotFound();

            var newItem = new IrrigationPlanItem_CropSowingAndIrrigation
            {
                IrrigationPlanItem = irrigationPlanItem,
                IrrigationPlanItemId = irrigationPlanItem.IrrigationPlanItemId
            };

            ViewBag.Crops = await _selectListRepository.GetSelectListCropsAsync();

            return View(newItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CropSowingAndIrrigationCreate(IrrigationPlanItem_CropSowingAndIrrigation irrigationPlanItem_CropSowingAndIrrigation)
        {
            if (ModelState.IsValid)
            {
                await _irrigationPlanRepository.AddIrrigationPlanItemCropSowingAndIrrigationAsync(irrigationPlanItem_CropSowingAndIrrigation);

                return RedirectToAction(nameof(CropSowingAndIrrigations), new { irrigationPlanItem_CropSowingAndIrrigation.IrrigationPlanItemId });
            }

            return RedirectToAction(nameof(CropSowingAndIrrigationCreate), new { irrigationPlanItem_CropSowingAndIrrigation.IrrigationPlanItemId });
        }

        public async Task<IActionResult> CropSowingAndIrrigationEdit(int irrigationPlanItem_CropSowingAndIrrigationId)
        {
            var entry = await _irrigationPlanRepository.GetIrrigationPlanItemCropSowingAndIrrigationAsync(irrigationPlanItem_CropSowingAndIrrigationId);
            if (entry == null) return NotFound();

            ViewBag.Crops = await _selectListRepository.GetSelectListCropsAsync(entry.CropId);
            return View(entry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CropSowingAndIrrigationEdit(IrrigationPlanItem_CropSowingAndIrrigation irrigationPlanItem_CropSowingAndIrrigation)
        {
            var entry = await _irrigationPlanRepository.GetIrrigationPlanItemCropSowingAndIrrigationAsync(irrigationPlanItem_CropSowingAndIrrigation.IrrigationPlanItem_CropSowingAndIrrigationId);
            if (entry == null) return NotFound();

            if (ModelState.IsValid)
            {
                entry.CropId = irrigationPlanItem_CropSowingAndIrrigation.CropId;
                entry.Sowing = irrigationPlanItem_CropSowingAndIrrigation.Sowing;
                entry.Irrigation = irrigationPlanItem_CropSowingAndIrrigation.Irrigation;

                await _irrigationPlanRepository.UpdateIrrigationPlanItemCropSowingAndIrrigationAsync(entry);

                return RedirectToAction(nameof(CropSowingAndIrrigations), new { irrigationPlanItem_CropSowingAndIrrigation.IrrigationPlanItemId });
            }

            ViewBag.Crops = await _selectListRepository.GetSelectListCropsAsync(entry.CropId);
            return View(entry);
        }


        public async Task<IActionResult> CropSowingAndIrrigationDelete(int irrigationPlanItem_CropSowingAndIrrigationId)
        {
            var entry = await _irrigationPlanRepository.GetIrrigationPlanItemCropSowingAndIrrigationAsync(irrigationPlanItem_CropSowingAndIrrigationId);
            if (entry == null) return NotFound();

            return View(entry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CropSowingAndIrrigationDeleteConfirmed(int irrigationPlanItem_CropSowingAndIrrigationId)
        {
            var entry = await _irrigationPlanRepository.GetIrrigationPlanItemCropSowingAndIrrigationAsync(irrigationPlanItem_CropSowingAndIrrigationId);
            if (entry == null) return NotFound();
            await _irrigationPlanRepository.RemoveIrrigationPlanItemCropSowingAndIrrigationAsync(entry); ;

            return RedirectToAction(nameof(CropSowingAndIrrigations), new { entry.IrrigationPlanItemId });
        }
        #endregion

        #region Причины отсутствия поливов
        public async Task<IActionResult> LandAreaNotIrrigationReasons(int irrigationPlanItemId)
        {
            var irrigationPlanItem = await _irrigationPlanRepository.GetIrrigationPlanItemAsync(irrigationPlanItemId);

            return View(irrigationPlanItem);
        }

        public async Task<IActionResult> LandAreaNotIrrigationReasonCreate(int irrigationPlanItemId)
        {
            var irrigationPlanItem = await _irrigationPlanRepository.GetIrrigationPlanItemAsync(irrigationPlanItemId);

            if (irrigationPlanItem == null) return NotFound();

            var newItem = new IrrigationPlanItem_LandAreaNotIrrigationReason
            {
                IrrigationPlanItem = irrigationPlanItem,
                IrrigationPlanItemId = irrigationPlanItem.IrrigationPlanItemId
            };

            ViewBag.Reasons = await _selectListRepository.GetSelectListReasonsAsync();

            return View(nameof(LandAreaNotIrrigationReasonEdit), newItem);
        }

        public async Task<IActionResult> LandAreaNotIrrigationReasonEdit(int irrigationPlanItem_LandAreaNotIrrigationReasonId)
        {
            var entry = await _irrigationPlanRepository.GetIrrigationPlanItemLandAreaNotIrrigationReasonAsync(irrigationPlanItem_LandAreaNotIrrigationReasonId);
            if (entry == null) return NotFound();

            ViewBag.Reasons = await _selectListRepository.GetSelectListReasonsAsync(entry.ReasonId);
            return View(entry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LandAreaNotIrrigationReasonEdit(IrrigationPlanItem_LandAreaNotIrrigationReason irrigationPlanItem_LandAreaNotIrrigationReason)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Reasons = await _selectListRepository.GetSelectListReasonsAsync(irrigationPlanItem_LandAreaNotIrrigationReason.ReasonId);
                return View(irrigationPlanItem_LandAreaNotIrrigationReason);
            }

            if (irrigationPlanItem_LandAreaNotIrrigationReason.Id == 0)
            {
                await _irrigationPlanRepository.UpdateIrrigationPlanItemLandAreaNotIrrigationReasonAsync(irrigationPlanItem_LandAreaNotIrrigationReason);
            }
            else
            {
                var entry = await _irrigationPlanRepository.GetIrrigationPlanItemLandAreaNotIrrigationReasonAsync(irrigationPlanItem_LandAreaNotIrrigationReason.Id);
                if (entry == null) return NotFound();

                entry.Area = irrigationPlanItem_LandAreaNotIrrigationReason.Area;
                entry.ReasonId = irrigationPlanItem_LandAreaNotIrrigationReason.ReasonId;

                await _irrigationPlanRepository.UpdateIrrigationPlanItemLandAreaNotIrrigationReasonAsync(entry);
            }

            return RedirectToAction(nameof(LandAreaNotIrrigationReasons), new { irrigationPlanItem_LandAreaNotIrrigationReason.IrrigationPlanItemId });
        }


        public async Task<IActionResult> LandAreaNotIrrigationReasonDelete(int irrigationPlanItem_LandAreaNotIrrigationReasonId)
        {
            var entry = await _irrigationPlanRepository.GetIrrigationPlanItemLandAreaNotIrrigationReasonAsync(irrigationPlanItem_LandAreaNotIrrigationReasonId);
            if (entry == null) return NotFound();

            return View(entry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LandAreaNotIrrigationReasonDeleteConfirmed(int irrigationPlanItem_LandAreaNotIrrigationReasonId)
        {
            var entry = await _irrigationPlanRepository.GetIrrigationPlanItemLandAreaNotIrrigationReasonAsync(irrigationPlanItem_LandAreaNotIrrigationReasonId);
            if (entry == null) return NotFound();
            await _irrigationPlanRepository.RemoveIrrigationPlanItemLandAreaNotIrrigationReasonAsync(entry);

            return RedirectToAction(nameof(LandAreaNotIrrigationReasons), new { entry.IrrigationPlanItemId });
        }
        #endregion

        #region Причины не с/х использования земель
        public async Task<IActionResult> LandAreaNotAgriculturalReasons(int irrigationPlanItemId)
        {
            var irrigationPlanItem = await _irrigationPlanRepository.GetIrrigationPlanItemAsync(irrigationPlanItemId);

            return View(irrigationPlanItem);
        }

        public async Task<IActionResult> LandAreaNotAgriculturalReasonCreate(int irrigationPlanItemId)
        {
            var irrigationPlanItem = await _irrigationPlanRepository.GetIrrigationPlanItemAsync(irrigationPlanItemId);

            if (irrigationPlanItem == null) return NotFound();

            var newItem = new IrrigationPlanItem_LandAreaNotAgriculturalReason
            {
                IrrigationPlanItem = irrigationPlanItem,
                IrrigationPlanItemId = irrigationPlanItem.IrrigationPlanItemId
            };

            ViewBag.Reasons = await _selectListRepository.GetSelectListReasonsAsync();

            return View(nameof(LandAreaNotAgriculturalReasonEdit), newItem);
        }

        public async Task<IActionResult> LandAreaNotAgriculturalReasonEdit(int irrigationPlanItem_LandAreaNotAgriculturalReasonId)
        {
            var entry = await _irrigationPlanRepository.GetIrrigationPlanItemLandAreaNotAgriculturalReasonAsync(irrigationPlanItem_LandAreaNotAgriculturalReasonId);
            if (entry == null) return NotFound();

            ViewBag.Reasons = await _selectListRepository.GetSelectListReasonsAsync(entry.ReasonId);
            return View(entry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LandAreaNotAgriculturalReasonEdit(IrrigationPlanItem_LandAreaNotAgriculturalReason irrigationPlanItem_LandAreaNotAgriculturalReason)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Reasons = await _selectListRepository.GetSelectListReasonsAsync(irrigationPlanItem_LandAreaNotAgriculturalReason.ReasonId);
                return View(irrigationPlanItem_LandAreaNotAgriculturalReason);
            }

            if (irrigationPlanItem_LandAreaNotAgriculturalReason.Id == 0)
            {
                await _irrigationPlanRepository.UpdateIrrigationPlanItemLandAreaNotAgriculturalReasonAsync(irrigationPlanItem_LandAreaNotAgriculturalReason);
            }
            else
            {
                var entry = await _irrigationPlanRepository.GetIrrigationPlanItemLandAreaNotAgriculturalReasonAsync(irrigationPlanItem_LandAreaNotAgriculturalReason.Id);
                if (entry == null) return NotFound();

                entry.Area = irrigationPlanItem_LandAreaNotAgriculturalReason.Area;
                entry.ReasonId = irrigationPlanItem_LandAreaNotAgriculturalReason.ReasonId;

                await _irrigationPlanRepository.UpdateIrrigationPlanItemLandAreaNotAgriculturalReasonAsync(entry);
            }

            return RedirectToAction(nameof(LandAreaNotAgriculturalReasons), new { irrigationPlanItem_LandAreaNotAgriculturalReason.IrrigationPlanItemId });
        }


        public async Task<IActionResult> LandAreaNotAgriculturalReasonDelete(int irrigationPlanItem_LandAreaNotAgriculturalReasonId)
        {
            var entry = await _irrigationPlanRepository.GetIrrigationPlanItemLandAreaNotAgriculturalReasonAsync(irrigationPlanItem_LandAreaNotAgriculturalReasonId);
            if (entry == null) return NotFound();

            return View(entry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LandAreaNotAgriculturalReasonDeleteConfirmed(int irrigationPlanItem_LandAreaNotAgriculturalReasonId)
        {
            var entry = await _irrigationPlanRepository.GetIrrigationPlanItemLandAreaNotAgriculturalReasonAsync(irrigationPlanItem_LandAreaNotAgriculturalReasonId);
            if (entry == null) return NotFound();
            await _irrigationPlanRepository.RemoveIrrigationPlanItemLandAreaNotAgriculturalReasonAsync(entry);

            return RedirectToAction(nameof(LandAreaNotAgriculturalReasons), new { entry.IrrigationPlanItemId });
        }
        #endregion
    }
}
