using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

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

        /// <summary>
        /// Инициализация базы данных
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static async Task InitDatabase(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            await InitDatabaseRoles.CreateRoles(serviceProvider, configuration);
            await InitDatabaseAdminAccount.CreateAdminAccount(serviceProvider, configuration);
            //await InitDatabaseUserData.CreateUserData(serviceProvider, configuration);            
        }

    }
}
