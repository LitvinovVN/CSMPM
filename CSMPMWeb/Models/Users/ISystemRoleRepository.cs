using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSMPMWeb.Models
{
    /// <summary>
    /// Интерфейс репозитория системных ролей
    /// </summary>
    public interface ISystemRoleRepository
    {
        Task<SystemRole> AddSystemRoleAsync(SystemRole systemRole);
        Task RemoveSystemRoleAsync(SystemRole systemRole);
        Task UpdateSystemRoleAsync(SystemRole systemRole);

        Task<SystemRole> GetSystemRoleAsync(int systemRoleId);
        Task<List<SystemRole>> GetSystemRolesAsync();
    }
}
