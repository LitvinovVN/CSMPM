using CSMPMLib;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CSMPMWeb.Models
{
    public class InitDatabaseIrrigationSystems
    {
        /// <summary>
        /// Инициализация справочника оросительных систем
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static async Task CreateIrrigationSystemsData(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                MySqlDbContext context = serviceScope.ServiceProvider.GetService<MySqlDbContext>();

                if (context.IrrigationSystems.Any()) return;

                var irrigationSystems = InitData.GetIrrigationSystems();

                await context.IrrigationSystems.AddRangeAsync(irrigationSystems);
                await context.SaveChangesAsync();
            }
        }
    }
}