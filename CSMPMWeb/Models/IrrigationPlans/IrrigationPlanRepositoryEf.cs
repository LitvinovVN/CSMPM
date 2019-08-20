using CSMPMLib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMPMWeb.Models
{
    /// <summary>
    /// Репозиторий планов поливов для Entity Framework
    /// </summary>
    public class IrrigationPlanRepositoryEf : IIrrigationPlanRepository
    {
        MySqlDbContext _context;

        public IrrigationPlanRepositoryEf(MySqlDbContext context)
        {
            _context = context;
        }

        public async Task<IrrigationPlan> AddIrrigationPlanAsync(IrrigationPlan irrigationPlan)
        {            
            await _context.IrrigationPlans.AddAsync(irrigationPlan);
            await _context.SaveChangesAsync();
            return irrigationPlan;
        }

        public async Task<IrrigationPlanItem> AddIrrigationPlanItemAsync(IrrigationPlanItem irrigationPlanItem)
        {
            await _context.IrrigationPlanItems.AddAsync(irrigationPlanItem);
            await _context.SaveChangesAsync();
            return irrigationPlanItem;
        }

        public async Task<IrrigationPlanItem_CropSowingAndIrrigation> AddIrrigationPlanItemCropSowingAndIrrigationAsync(IrrigationPlanItem_CropSowingAndIrrigation irrigationPlanItem_CropSowingAndIrrigation)
        {
            await _context.IrrigationPlanItem_CropSowingAndIrrigations.AddAsync(irrigationPlanItem_CropSowingAndIrrigation);
            await _context.SaveChangesAsync();
            return irrigationPlanItem_CropSowingAndIrrigation;
        }

        public async Task<IrrigationPlanItem_LandAreaNotAgriculturalReason> AddIrrigationPlanItemLandAreaNotAgriculturalReasonAsync(IrrigationPlanItem_LandAreaNotAgriculturalReason irrigationPlanItem_LandAreaNotAgriculturalReason)
        {
            await _context.AddAsync(irrigationPlanItem_LandAreaNotAgriculturalReason);
            await _context.SaveChangesAsync();
            return irrigationPlanItem_LandAreaNotAgriculturalReason;
        }

        public async Task<IrrigationPlanItem_LandAreaNotIrrigationReason> AddIrrigationPlanItemLandAreaNotIrrigationReasonAsync(IrrigationPlanItem_LandAreaNotIrrigationReason irrigationPlanItem_LandAreaNotIrrigationReason)
        {
            await _context.AddAsync(irrigationPlanItem_LandAreaNotIrrigationReason);
            await _context.SaveChangesAsync();
            return irrigationPlanItem_LandAreaNotIrrigationReason;
        }

        public async Task<IrrigationPlan> GetIrrigationPlanAsync(int irrigationPlanId)
        {
            var irrigationPlan = await _context.IrrigationPlans
                .Include(ip => ip.OrganizationDocumentationPlans.OrganizationDocumentation.Organization)
                .Include(ip => ip.IrrigationPlanItems)
                    .ThenInclude(ipi => ipi.IrrigationSystem)
                .FirstOrDefaultAsync(ip => ip.IrrigationPlanId == irrigationPlanId);
            return irrigationPlan;
        }

        public async Task<IrrigationPlanItem> GetIrrigationPlanItemAsync(int irrigationPlanItemId)
        {
            var irrigationPlanItem = await _context.IrrigationPlanItems
                .Include(i => i.IrrigationPlan.OrganizationDocumentationPlans.OrganizationDocumentation.Organization)
                .Include(ipi => ipi.IrrigationSystem)
                .Include(i => i.IrrigationPlanItem_CropSowingAndIrrigations)
                    .ThenInclude(csi=>csi.Crop.CropGroup)
                .Include(i => i.IrrigationPlanItem_LandAreaNotIrrigationReasons)
                    .ThenInclude(lnr=>lnr.Reason)
                .Include(i => i.IrrigationPlanItem_LandAreaNotAgriculturalReasons)
                    .ThenInclude(lna => lna.Reason)
                .FirstOrDefaultAsync(items=>items.IrrigationPlanItemId == irrigationPlanItemId);

            return irrigationPlanItem;
        }

        public async Task<IrrigationPlanItem_CropSowingAndIrrigation> GetIrrigationPlanItemCropSowingAndIrrigationAsync(int irrigationPlanItem_CropSowingAndIrrigationId)
        {
            var entry = await _context.IrrigationPlanItem_CropSowingAndIrrigations
                .Include(i=>i.IrrigationPlanItem.IrrigationPlan.OrganizationDocumentationPlans.OrganizationDocumentation.Organization)
                .Include(i => i.IrrigationPlanItem.IrrigationSystem)
                .Include(i=>i.Crop.CropGroup)
                .FirstOrDefaultAsync(i => i.IrrigationPlanItem_CropSowingAndIrrigationId == irrigationPlanItem_CropSowingAndIrrigationId);
            return entry;
        }

        public async Task<IrrigationPlanItem_LandAreaNotAgriculturalReason> GetIrrigationPlanItemLandAreaNotAgriculturalReasonAsync(int irrigationPlanItem_LandAreaNotAgriculturalReasonId)
        {
            var entry = await _context.IrrigationPlanItem_LandAreaNotAgriculturalReasons
                .Include(i => i.IrrigationPlanItem.IrrigationPlan.OrganizationDocumentationPlans.OrganizationDocumentation.Organization)
                .Include(i => i.IrrigationPlanItem.IrrigationSystem)
                .Include(i => i.Reason)
                .FirstOrDefaultAsync(i => i.Id == irrigationPlanItem_LandAreaNotAgriculturalReasonId);
            return entry;
        }

        public async Task<IrrigationPlanItem_LandAreaNotIrrigationReason> GetIrrigationPlanItemLandAreaNotIrrigationReasonAsync(int irrigationPlanItem_LandAreaNotIrrigationReasonId)
        {
            var entry = await _context.IrrigationPlanItem_LandAreaNotIrrigationReasons
                .Include(i => i.IrrigationPlanItem.IrrigationPlan.OrganizationDocumentationPlans.OrganizationDocumentation.Organization)
                .Include(i => i.IrrigationPlanItem.IrrigationSystem)
                .Include(i => i.Reason)
                .FirstOrDefaultAsync(i => i.Id == irrigationPlanItem_LandAreaNotIrrigationReasonId);
            return entry;
        }

        public async Task<List<IrrigationPlan>> GetIrrigationPlansAsync()
        {
            return await _context.IrrigationPlans
                .Include(ip => ip.OrganizationDocumentationPlans.OrganizationDocumentation.Organization)
                .OrderBy(ip => ip.Year)
                .ToListAsync();
        }

        public async Task RemoveIrrigationPlanAsync(IrrigationPlan irrigationPlan)
        {
            _context.Remove(irrigationPlan);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveIrrigationPlanItemAsync(IrrigationPlanItem irrigationPlanItem)
        {
            _context.Remove(irrigationPlanItem);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveIrrigationPlanItemCropSowingAndIrrigationAsync(IrrigationPlanItem_CropSowingAndIrrigation entry)
        {
            _context.Remove(entry);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveIrrigationPlanItemLandAreaNotAgriculturalReasonAsync(IrrigationPlanItem_LandAreaNotAgriculturalReason entry)
        {
            _context.Remove(entry);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveIrrigationPlanItemLandAreaNotIrrigationReasonAsync(IrrigationPlanItem_LandAreaNotIrrigationReason entry)
        {
            _context.Remove(entry);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateIrrigationPlanAsync(IrrigationPlan irrigationPlan)
        {
            _context.IrrigationPlans.Update(irrigationPlan);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateIrrigationPlanItemAsync(IrrigationPlanItem irrigationPlanItem)
        {
            _context.IrrigationPlanItems.Update(irrigationPlanItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateIrrigationPlanItemCropSowingAndIrrigationAsync(IrrigationPlanItem_CropSowingAndIrrigation entry)
        {
            _context.IrrigationPlanItem_CropSowingAndIrrigations.Update(entry);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateIrrigationPlanItemLandAreaNotAgriculturalReasonAsync(IrrigationPlanItem_LandAreaNotAgriculturalReason entry)
        {
            _context.Update(entry);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateIrrigationPlanItemLandAreaNotIrrigationReasonAsync(IrrigationPlanItem_LandAreaNotIrrigationReason entry)
        {
            _context.Update(entry);
            await _context.SaveChangesAsync();
        }
    }
}
