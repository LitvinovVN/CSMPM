using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMPMWeb.Models
{
    /// <summary>
    /// Инициализация ролей пользователей, являющихся сотрудниками организаций
    /// </summary>
    public static class InitDatabaseSystemRoles
    {
        /// <summary>
        /// Инициализация ролей пользователей, являющихся сотрудниками организаций
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static async Task CreateSystemRoles(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                MySqlDbContext context = serviceScope.ServiceProvider.GetService<MySqlDbContext>();

                if (context.SystemRoles.Any()) return;

                List<SystemRole> systemRoles = new List<SystemRole>
                {
                    new SystemRole{SystemRoleName = "Администраторы организации" },
                    new SystemRole{SystemRoleName = "Сотрудники организации" }
                };

                await context.SystemRoles.AddRangeAsync(systemRoles);
                await context.SaveChangesAsync();
            }
        }
    }
}
