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
    public static class InitDatabaseReasons
    {
        /// <summary>
        /// Инициализация справочника причин невыполнения
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static async Task CreateReasonsData(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                MySqlDbContext context = serviceScope.ServiceProvider.GetService<MySqlDbContext>();

                if (context.Reasons.Any()) return;

                var reasons = InitData.GetReasons();

                await context.Reasons.AddRangeAsync(reasons);
                await context.SaveChangesAsync();
            }
        }
    }
}
