using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSMPMLib
{
    /// <summary>
    /// Интерфейс репозитория сельскохозяйственных культур
    /// </summary>
    public interface IIrrigationSystemRepository
    {        
        Task<List<IrrigationSystem>> GetIrrigationSystemsAsync();
        Task<IrrigationSystem> GetIrrigationSystemAsync(int irrigationSystemId);
        Task<IrrigationSystem> AddIrrigationSystemAsync(IrrigationSystem irrigationSystem);
        Task RemoveIrrigationSystemAsync(IrrigationSystem irrigationSystem);
        Task UpdateIrrigationSystemAsync(IrrigationSystem irrigationSystem);

        Task<OrganizationToTypeOfActivitiesToIrrigationSystem> GetOrganizationToTypeOfActivitiesToIrrigationSystemAsync(int id);
        Task UpdateOrganizationToTypeOfActivitiesToIrrigationSystemAsync(OrganizationToTypeOfActivitiesToIrrigationSystem model);

        /// <summary>
        /// Изменяет тип взаимодействия организации с оросительной системой
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="typeOfActivityId"></param>
        /// <param name="irrigationSystemId"></param>
        /// <returns></returns>
        Task<OrganizationToTypeOfActivity> ChangeTypeOfActivityOfOrganizationForIrrigationSystemAsync(int organizationId, int typeOfActivityId, int irrigationSystemId);

        /// <summary>
        /// Добавляет тип взаимодействия организации с оросительной системой
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="typeOfActivityId"></param>
        /// <param name="irrigationSystemId"></param>
        /// <returns></returns>
        Task<OrganizationToTypeOfActivity> AddTypeOfActivityOfOrganizationForIrrigationSystemAsync(int organizationId, int typeOfActivityId, int irrigationSystemId);

        /// <summary>
        /// Удаляет привязку оросительной системы к привязке организации к виду деятельности
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task RemoveOrganizationToTypeOfActivitiesToIrrigationSystemAsync(OrganizationToTypeOfActivitiesToIrrigationSystem model);        
    }
}
