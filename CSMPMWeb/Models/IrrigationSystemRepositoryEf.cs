using CSMPMLib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMPMWeb.Models
{
    /// <summary>
    /// Репозиторий оросительных систем
    /// </summary>
    public class IrrigationSystemRepositoryEf : IIrrigationSystemRepository
    {
        MySqlDbContext _context;

        public IrrigationSystemRepositoryEf(MySqlDbContext context)
        {
            _context = context;
        }

        public async Task<IrrigationSystem> AddIrrigationSystemAsync(IrrigationSystem irrigationSystem)
        {
            throw new NotImplementedException();
        }

        public async Task<IrrigationSystem> GetIrrigationSystemAsync(int irrigationSystemId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<IrrigationSystem>> GetIrrigationSystemsAsync()
        {
            var irrigationSystems = await _context.IrrigationSystems
                .Include(i => i.OrganizationToIrrigationSystem)
                    .ThenInclude(os=>os.Organization)
                .ToListAsync();
            return irrigationSystems;
        }

        public async Task RemoveIrrigationSystemAsync(IrrigationSystem irrigationSystem)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateIrrigationSystemAsync(IrrigationSystem irrigationSystem)
        {
            throw new NotImplementedException();
        }
    }
}
