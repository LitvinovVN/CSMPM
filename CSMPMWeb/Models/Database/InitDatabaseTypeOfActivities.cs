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
    /// Инициализация справочника причин невыполнения каких-либо мероприятий, показателей и пр.
    /// </summary>
    public static class InitDatabaseTypeOfActivities
    {
        /// <summary>
        /// Инициализация справочника причин невыполнения
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static async Task CreateTypeOfActivitiesData(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                MySqlDbContext context = serviceScope.ServiceProvider.GetService<MySqlDbContext>();

                if (context.TypeOfActivities.Any()) return;

                var types = InitData.GetTypeOfActivities();

                await context.TypeOfActivities.AddRangeAsync(types);
                await context.SaveChangesAsync();
            }
        }
    }
}
