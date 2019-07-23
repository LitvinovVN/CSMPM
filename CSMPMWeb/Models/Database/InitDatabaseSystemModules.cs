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
    public static class InitDatabaseSystemModules
    {
        /// <summary>
        /// Инициализация ролей пользователей, являющихся сотрудниками организаций
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static async Task CreateSystemModules(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                MySqlDbContext context = serviceScope.ServiceProvider.GetService<MySqlDbContext>();

                if (context.SystemModules.Any()) return;

                List<SystemModule> systemModules = new List<SystemModule>
                {                    
                    new SystemModule{ SystemModuleName = "Мелиорация" }
                };

                await context.SystemModules.AddRangeAsync(systemModules);
                await context.SaveChangesAsync();
            }
        }
    }
}
