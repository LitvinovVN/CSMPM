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

        /// <summary>
        /// Возвращает привязки "Организация - Системный модуль" для указанного УИД организации
        /// </summary>
        /// <param name="organizationId">УИД организации</param>
        /// <returns></returns>
        Task<List<OrganizationToSystemModule>> GetOrganizationToSystemModulesAsync(int organizationId);

        /// <summary>
        /// Возвращает привязку системного модуля к организации
        /// </summary>
        /// <param name="id"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        Task<OrganizationToSystemModule> GetOrganizationToSystemModuleAsync(int systemModuleId, int organizationId);

        /// <summary>
        /// Привязывает модуль к организации
        /// </summary>
        /// <param name="systemModuleId"></param>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        Task BindSystemModuleToOrganizationAsync(int systemModuleId, int organizationId);

        /// <summary>
        /// Отвязывает модуль от организации
        /// </summary>
        /// <param name="systemModuleId"></param>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        Task UnbindSystemModuleFromOrganizationAsync(int systemModuleId, int organizationId);
    }
}
