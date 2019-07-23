using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSMPMWeb.Models
{
    /// <summary>
    /// Интерфейс репозитория модулей системы
    /// </summary>
    public interface ISystemModuleRepository
    {
        Task<SystemModule> AddSystemModuleAsync(SystemModule systemModule);
        Task RemoveSystemModuleAsync(SystemModule systemModule);
        Task UpdateSystemModuleAsync(SystemModule systemModule);

        Task<SystemModule> GetSystemModuleAsync(int systemModuleId);
        Task<List<SystemModule>> GetSystemModulesAsync();
    }
}
