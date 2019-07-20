using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using CSMPMLib;

namespace CSMPMWeb.Models
{
    /// <summary>
    /// Класс контекста БД
    /// </summary>
    public class MySqlDbContext : IdentityDbContext<AppUser>
    {
        #region Конструктор
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
        {

        }
        #endregion

        #region Инициализация базы данных
        /// <summary>
        /// Инициализация базы данных
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static async Task InitDatabase(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            await InitDatabaseCropGroupsCrops.CreateCropsData(serviceProvider, configuration);

            await InitDatabaseRoles.CreateRoles(serviceProvider, configuration);
            await InitDatabaseAdminAccount.CreateAdminAccount(serviceProvider, configuration);
            //await InitDatabaseUserData.CreateUserData(serviceProvider, configuration);            
        }
        #endregion

        #region Таблицы
        /// <summary>
        /// Группы с/х культур
        /// </summary>        
        public DbSet<CropGroup> CropGroups { get; set; }

        /// <summary>
        /// С/х культуры
        /// </summary>
        public DbSet<Crop> Crops { get; set; }
        #endregion
    }
}
