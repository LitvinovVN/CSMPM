using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMPMWeb.Models
{
    /// <summary>
    /// Репозиторий EF ролей пользователей, связанных с организациями
    /// </summary>
    public class SystemRoleRepositoryEf : ISystemRoleRepository
    {
        MySqlDbContext _context;

        public SystemRoleRepositoryEf(MySqlDbContext context)
        {
            _context = context;
        }

        public async Task<SystemRole> AddSystemRoleAsync(SystemRole systemRole)
        {
            await _context.SystemRoles.AddAsync(systemRole);
            return systemRole;
        }

        public async Task<SystemRole> GetSystemRoleAsync(int systemRoleId)
        {
            var systemRole = await _context.SystemRoles.FirstOrDefaultAsync(sr => sr.SystemRoleId == systemRoleId);
            return systemRole;
        }

        public async Task<List<SystemRole>> GetSystemRolesAsync()
        {
            var systemRoles = await _context.SystemRoles.ToListAsync();
            return systemRoles;
        }

        public async Task RemoveSystemRoleAsync(SystemRole systemRole)
        {
            _context.SystemRoles.Remove(systemRole);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSystemRoleAsync(SystemRole systemRole)
        {
            _context.SystemRoles.Update(systemRole);
            await _context.SaveChangesAsync();
        }
    }
}
