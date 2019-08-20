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
            await InitDatabaseTypeOfActivities.CreateTypeOfActivitiesData(serviceProvider, configuration);
            await InitDatabaseReasons.CreateReasonsData(serviceProvider, configuration);

            await InitDatabaseCropGroupsCrops.CreateCropsData(serviceProvider, configuration);

            await InitDatabaseIrrigationSystems.CreateIrrigationSystemsData(serviceProvider, configuration);
            await InitDatabaseOrganizations.CreateOrganizationsData(serviceProvider, configuration);            
                       

            await InitDatabaseRoles.CreateRoles(serviceProvider, configuration);
            await InitDatabaseAdminAccount.CreateAdminAccount(serviceProvider, configuration);
            await InitDatabaseUserData.CreateUserData(serviceProvider, configuration);            
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
        /// Справочник видов деятельности организаций
        /// </summary>
        public DbSet<TypeOfActivity> TypeOfActivities { get; set; }

        /// <summary>
        /// Привязка организаций к видам деятельности
        /// </summary>
        public DbSet<OrganizationToTypeOfActivity> OrganizationToTypeOfActivities { get; set; }

        /// <summary>
        /// Таблица сопоставления организации и оросительной системы с указанием типа взаимосвязи
        /// </summary>
        public DbSet<OrganizationToIrrigationSystem> OrganizationToIrrigationSystems { get; set; }

        /// <summary>
        /// Типы взаимосвязей организации и технической системы
        /// </summary>
        public DbSet<OrganizationToSystemRelationType> OrganizationToSystemRelationTypes { get; set; }


        #region Документация организации
        /// <summary>
        /// Справочник причин невыполнения чего-либо
        /// </summary>
        public DbSet<Reason> Reasons { get; set; }
        
        /// <summary>
        /// Документация организации
        /// </summary>
        public DbSet<OrganizationDocumentationItem> OrganizationDocumentation { get; set; }

        /// <summary>
        /// Документация организации. Планы
        /// </summary>
        public DbSet<OrganizationDocumentationPlans> OrganizationDocumentationPlans { get; set; }

        #region Планы полива
        /// <summary>
        /// Планы полива
        /// </summary>
        public DbSet<IrrigationPlan> IrrigationPlans { get; set; }

        /// <summary>
        /// План полива. Записи плана
        /// </summary>
        public DbSet<IrrigationPlanItem> IrrigationPlanItems { get; set; }

        /// <summary>
        /// План полива. Запись плана. С/х культура - посев - полив
        /// </summary>
        public DbSet<IrrigationPlanItem_CropSowingAndIrrigation> IrrigationPlanItem_CropSowingAndIrrigations { get; set; }

        /// <summary>
        /// План полива. Запись плана. Площади земель не сх назначения с указанием причины
        /// </summary>
        public DbSet<IrrigationPlanItem_LandAreaNotAgriculturalReason> IrrigationPlanItem_LandAreaNotAgriculturalReasons { get; set; }

        /// <summary>
        /// План полива. Запись плана. Площади земель без полива с указанием причины
        /// </summary>
        public DbSet<IrrigationPlanItem_LandAreaNotIrrigationReason> IrrigationPlanItem_LandAreaNotIrrigationReasons { get; set; }
        #endregion

        
        #endregion

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
