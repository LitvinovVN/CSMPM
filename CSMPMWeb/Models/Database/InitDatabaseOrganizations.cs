using CSMPMLib;
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
    /// Инициализация справочников групп с\х культур и с\х культур
    /// </summary>
    public static class InitDatabaseOrganizations
    {
        /// <summary>
        /// Инициализация справочника организаций
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static async Task CreateOrganizationsData(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                MySqlDbContext context = serviceScope.ServiceProvider.GetService<MySqlDbContext>();
                
                if(!context.Organizations.Any())
                {
                    var data = InitData.GetOrganizations();

                    await context.AddRangeAsync(data);
                    await context.SaveChangesAsync();
                }                
            }
        }
    }
}
