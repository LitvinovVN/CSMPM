using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMPMWeb.Models
{
    /// <summary>
    /// Репозиторий EF модулей системы
    /// </summary>
    public class SystemModuleRepositoryEf : ISystemModuleRepository
    {
        MySqlDbContext _context;

        public SystemModuleRepositoryEf(MySqlDbContext context)
        {
            _context = context;
        }

        public async Task<SystemModule> AddSystemModuleAsync(SystemModule systemModule)
        {
            await _context.SystemModules.AddAsync(systemModule);
            return systemModule;
        }

        public async Task<SystemModule> GetSystemModuleAsync(int systemModuleId)
        {
            var systemModule = await _context.SystemModules.FirstOrDefaultAsync(sr => sr.SystemModuleId == systemModuleId);
            return systemModule;
        }

        public async Task<List<SystemModule>> GetSystemModulesAsync()
        {
            var systemModules = await _context.SystemModules.ToListAsync();
            return systemModules;
        }

        public async Task RemoveSystemModuleAsync(SystemModule systemModule)
        {
            _context.SystemModules.Remove(systemModule);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSystemModuleAsync(SystemModule systemModule)
        {
            _context.SystemModules.Update(systemModule);
            await _context.SaveChangesAsync();
        }
    }
}
