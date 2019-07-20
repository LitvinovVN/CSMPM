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
    public static class InitDatabaseCropGroupsCrops
    {
        /// <summary>
        /// Инициализация справочников групп с\х культур и с\х культур
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static async Task CreateCropsData(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                MySqlDbContext context = serviceScope.ServiceProvider.GetService<MySqlDbContext>();
                
                if(!context.CropGroups.Any())
                {
                    var data = InitData.GetCropGroups_Crops();
                    try
                    {
                        await context.AddRangeAsync(data);
                        await context.SaveChangesAsync();
                    }
                    catch(Exception exc)
                    {
                        //logger
                    }
                }                
            }
        }
    }
}
