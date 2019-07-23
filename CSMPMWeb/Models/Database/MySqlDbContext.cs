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
            await InitDatabaseSystemRoles.CreateSystemRoles(serviceProvider, configuration);
            await InitDatabaseSystemModules.CreateSystemModules(serviceProvider, configuration);

            await InitDatabaseCropGroupsCrops.CreateCropsData(serviceProvider, configuration);

            await InitDatabaseOrganizations.CreateOrganizationsData(serviceProvider, configuration);

            await InitDatabaseRoles.CreateRoles(serviceProvider, configuration);
            await InitDatabaseAdminAccount.CreateAdminAccount(serviceProvider, configuration);
            //await InitDatabaseUserData.CreateUserData(serviceProvider, configuration);            
        }
        #endregion

        #region Таблицы
        #region С\х культуры
        /// <summary>
        /// Группы с/х культур
        /// </summary>        
        public DbSet<CropGroup> CropGroups { get; set; }

        /// <summary>
        /// С/х культуры
        /// </summary>
        public DbSet<Crop> Crops { get; set; }
        #endregion

        #region Организации, пользователи и права доступа
        /// <summary>
        /// Организации
        /// </summary>
        public DbSet<Organization> Organizations { get; set; }

        /// <summary>
        /// Таблица сопоставления организации и оросительной системы с указанием типа взаимосвязи
        /// </summary>
        public DbSet<OrganizationToIrrigationSystem> OrganizationToIrrigationSystems { get; set; }

        /// <summary>
        /// Типы взаимосвязей организации и технической системы
        /// </summary>
        public DbSet<OrganizationToSystemRelationType> OrganizationToSystemRelationTypes { get; set; }

        /// <summary>
        /// Привязки пользователей к организациям
        /// </summary>
        public DbSet<AppUserToOrganization> AppUserToOrganizations { get; set; }

        /// <summary>
        /// Назначения разрешений на использование модулей системы
        /// </summary>
        public DbSet<AssignedPermission> AssignedPermissions { get; set; }

        /// <summary>
        /// Модули системы
        /// </summary>
        public DbSet<SystemModule> SystemModules { get; set; }

        /// <summary>
        /// Роли пользователей при работе с модулями системы
        /// </summary>
        public DbSet<SystemRole> SystemRoles { get; set; }
        #endregion

        #region Орошение
        /// <summary>
        /// Оросительные системы
        /// </summary>
        public DbSet<IrrigationSystem> IrrigationSystems { get; set; }

        /// <summary>
        /// Оросительные сети
        /// </summary>
        public DbSet<IrrigationGrid> IrrigationGrids { get; set; }
        
        /// <summary>
        /// Оросительные каналы
        /// </summary>
        public DbSet<IrrigationCanal> IrrigationCanals { get; set; }

        /// <summary>
        /// Точки присоединения к оросительным каналам
        /// </summary>
        public DbSet<IrrigationCanalConnectionPoint> IrrigationCanalConnectionPoints { get; set; }

        /// <summary>
        /// Типы присоединения точки к оросительному каналу
        /// </summary>
        public DbSet<IrrigationCanalConnectionPointType> IrrigationCanalConnectionPointTypes { get; set; }

        /// <summary>
        /// Связующая таблица для хранения принадлежности точки присоединения оросительным каналам с указанием типа принадлежности
        /// </summary>
        public DbSet<IrrigationCanalConnectionPointToIrrigationCanal> IrrigationCanalConnectionPointToIrrigationCanals { get; set; }
        #endregion
        
        #endregion
    }
}
