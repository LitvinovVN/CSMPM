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

        public async Task<IrrigationPlan> GetIrrigationPlanAsync(int irrigationPlanId)
        {
            var irrigationPlan = await _context.IrrigationPlans
                .Include(ip => ip.IrrigationPlanItems)
                .FirstOrDefaultAsync(ip => ip.IrrigationPlanId == irrigationPlanId);
            return irrigationPlan;
        }

        public async Task<List<IrrigationPlan>> GetIrrigationPlansAsync()
        {
            return await _context.IrrigationPlans
                .OrderBy(ip => ip.Year)
                .ToListAsync();
        }

        public async Task RemoveIrrigationPlanAsync(IrrigationPlan irrigationPlan)
        {
            _context.Remove(irrigationPlan);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateIrrigationPlanAsync(IrrigationPlan irrigationPlan)
        {
            _context.IrrigationPlans.Update(irrigationPlan);
            await _context.SaveChangesAsync();
        }
    }
}
