using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSMPMLib
{
    /// <summary>
    /// Интерфейс репозитория организаций
    /// </summary>
    public interface IOrganizationRepository
    {        
        Task<List<Organization>> GetOrganizationsAsync(HierarchyLoadModesEnum hierarchyLoadModes = HierarchyLoadModesEnum.FullHierarchy);
        Task<Organization> GetOrganizationAsync(int organizationId);
        Task<Organization> AddOrganizationAsync(Organization organization);
        Task RemoveOrganizationAsync(Organization organization);
        Task UpdateOrganizationAsync(Organization organization);        
    }
}
