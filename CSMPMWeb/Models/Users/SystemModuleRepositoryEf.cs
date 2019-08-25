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

        /// <summary>
        /// Возвращает список привязок "Организация - Модуль системы" для указанного УИД организации
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        public async Task<List<OrganizationToSystemModule>> GetOrganizationToSystemModulesAsync(int organizationId)
        {
            var result = await _context.OrganizationToSystemModules
                .Include(o => o.SystemModule)
                .Where(o => o.OrganizationId == organizationId)
                .OrderBy(o => o.SystemModule.SystemModuleName)
                .ToListAsync();

            return result;
        }

        /// <summary>
        /// Возвращает привязку модуля к организации, если она существует
        /// </summary>
        /// <param name="systemModuleId"></param>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        public async Task<OrganizationToSystemModule> GetOrganizationToSystemModuleAsync(int systemModuleId, int organizationId)
        {
            var entry = await _context.OrganizationToSystemModules
                .Include(osm => osm.Organization)
                .Include(osm => osm.SystemModule)
                .FirstOrDefaultAsync(osm => osm.SystemModuleId == systemModuleId && osm.OrganizationId == organizationId);
            return entry;
        }

        /// <summary>
        /// Привязывает модуль к организации
        /// </summary>
        /// <param name="systemModuleId"></param>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        public async Task BindSystemModuleToOrganizationAsync(int systemModuleId, int organizationId)
        {
            // Проверяем существование такой же привязки
            bool isExist = await _context.OrganizationToSystemModules
                .AnyAsync(osm => osm.SystemModuleId == systemModuleId && osm.OrganizationId == organizationId);

            if (!isExist)
            {
                await _context.OrganizationToSystemModules.AddAsync(new OrganizationToSystemModule
                {
                    SystemModuleId = systemModuleId,
                    OrganizationId = organizationId
                });
                await _context.SaveChangesAsync();
            }                
        }

        /// <summary>
        /// Отвязывает модуль от организации
        /// </summary>
        /// <param name="systemModuleId"></param>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        public async Task UnbindSystemModuleFromOrganizationAsync(int systemModuleId, int organizationId)
        {            
            var entry = await _context.OrganizationToSystemModules
                .FirstOrDefaultAsync(osm => osm.SystemModuleId == systemModuleId && osm.OrganizationId == organizationId);

            if (entry!=null)
            {
                _context.OrganizationToSystemModules.Remove(entry);
                await _context.SaveChangesAsync();
            }
        }
    }
}
