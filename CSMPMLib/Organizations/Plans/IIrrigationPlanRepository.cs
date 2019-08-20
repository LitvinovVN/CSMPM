using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSMPMLib
{
    /// <summary>
    /// Интерфейс репозитория планов поливов
    /// </summary>
    public interface IIrrigationPlanRepository
    {        
        Task<List<IrrigationPlan>> GetIrrigationPlansAsync();
        Task<IrrigationPlan> GetIrrigationPlanAsync(int irrigationPlanId);
        Task<IrrigationPlan> AddIrrigationPlanAsync(IrrigationPlan irrigationPlan);
        Task RemoveIrrigationPlanAsync(IrrigationPlan irrigationPlan);
        Task UpdateIrrigationPlanAsync(IrrigationPlan irrigationPlan);

        Task<IrrigationPlanItem> GetIrrigationPlanItemAsync(int irrigationPlanItemId);
        Task<IrrigationPlanItem> AddIrrigationPlanItemAsync(IrrigationPlanItem irrigationPlanItem);
        Task RemoveIrrigationPlanItemAsync(IrrigationPlanItem irrigationPlanItem);
        Task UpdateIrrigationPlanItemAsync(IrrigationPlanItem irrigationPlanItem);

        Task<IrrigationPlanItem_CropSowingAndIrrigation> AddIrrigationPlanItemCropSowingAndIrrigationAsync(IrrigationPlanItem_CropSowingAndIrrigation irrigationPlanItem_CropSowingAndIrrigation);
        Task<IrrigationPlanItem_CropSowingAndIrrigation> GetIrrigationPlanItemCropSowingAndIrrigationAsync(int irrigationPlanItem_CropSowingAndIrrigationId);
        Task UpdateIrrigationPlanItemCropSowingAndIrrigationAsync(IrrigationPlanItem_CropSowingAndIrrigation entry);
        Task RemoveIrrigationPlanItemCropSowingAndIrrigationAsync(IrrigationPlanItem_CropSowingAndIrrigation entry);

        Task<IrrigationPlanItem_LandAreaNotIrrigationReason> AddIrrigationPlanItemLandAreaNotIrrigationReasonAsync(IrrigationPlanItem_LandAreaNotIrrigationReason irrigationPlanItem_LandAreaNotIrrigationReason);
        Task<IrrigationPlanItem_LandAreaNotIrrigationReason> GetIrrigationPlanItemLandAreaNotIrrigationReasonAsync(int irrigationPlanItem_LandAreaNotIrrigationReasonId);
        Task UpdateIrrigationPlanItemLandAreaNotIrrigationReasonAsync(IrrigationPlanItem_LandAreaNotIrrigationReason entry);
        Task RemoveIrrigationPlanItemLandAreaNotIrrigationReasonAsync(IrrigationPlanItem_LandAreaNotIrrigationReason entry);

        Task<IrrigationPlanItem_LandAreaNotAgriculturalReason> AddIrrigationPlanItemLandAreaNotAgriculturalReasonAsync(IrrigationPlanItem_LandAreaNotAgriculturalReason irrigationPlanItem_LandAreaNotAgriculturalReason);
        Task<IrrigationPlanItem_LandAreaNotAgriculturalReason> GetIrrigationPlanItemLandAreaNotAgriculturalReasonAsync(int irrigationPlanItem_LandAreaNotAgriculturalReasonId);
        Task UpdateIrrigationPlanItemLandAreaNotAgriculturalReasonAsync(IrrigationPlanItem_LandAreaNotAgriculturalReason entry);
        Task RemoveIrrigationPlanItemLandAreaNotAgriculturalReasonAsync(IrrigationPlanItem_LandAreaNotAgriculturalReason entry);        
    }
}
