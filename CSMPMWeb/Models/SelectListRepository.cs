using CSMPMLib;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMPMWeb.Models
{
    /// <summary>
    /// Репозиторий списков (справочников)
    /// </summary>
    public class SelectListRepository
    {
        MySqlDbContext _context;
        IOrganizationRepository _organizationRepository;
        AppUserRepository _appUserRepository;

        public SelectListRepository(MySqlDbContext context,
            IOrganizationRepository organizationRepository,
            AppUserRepository appUserRepository)
        {
            _context = context;
            _organizationRepository = organizationRepository;
            _appUserRepository = appUserRepository;
        }

        /// <summary>
        /// Возвращает список организаций
        /// </summary>        
        public async Task<SelectList> GetSelectListOrganizationsAsync(int selectedId = 0)
        {
            List<Organization> items = new List<Organization>();
            items = await _context.Organizations.OrderBy(o => o.OrganizationName).ToListAsync();
                        
            //var rootOrganizationsWithAllChilds = await _organizationRepository.GetOrganizationsAsync(HierarchyLoadModesEnum.RootElements);

            //int level = 0;
            //HieararchyWalk(rootOrganizationsWithAllChilds, level, items);
            
            var selectList = new SelectList(items, "OrganizationId", "OrganizationName", selectedId);
            return selectList;
        }
              

        /// <summary>
        /// Возвращает список видов деятельности организации 
        /// </summary>
        /// <param name="selectedId"></param>
        /// <returns></returns>
        public async Task<SelectList> GetSelectListTypeOfActivitiesAsync(int selectedId = 0)
        {
            var items = await _context.TypeOfActivities.ToListAsync();

            var selectList = new SelectList(items,
                nameof(TypeOfActivity.TypeOfActivityId),
                nameof(TypeOfActivity.TypeOfActivityName),
                selectedId);
            return selectList;
        }

        /// <summary>
        /// Возвращает список видов деятельности организации по мелиорации
        /// </summary>
        /// <returns></returns>
        public async Task<SelectList> GetSelectListTypeOfActivitiesMeliorationAsync(int selectedId = 0)
        {
            var items = await _context.TypeOfActivities
                .Where(ta=>ta.RootTypeOfActivityId == 1)
                .ToListAsync();

            var selectList = new SelectList(items,
                nameof(TypeOfActivity.TypeOfActivityId),
                nameof(TypeOfActivity.TypeOfActivityName),
                selectedId);
            return selectList;
        }

        /// <summary>
        /// Возвращает список модулей системы
        /// </summary>
        /// <returns></returns>
        public async Task<SelectList> GetSelectListSystemModulesAsync(int selectedId = 0)
        {
            var items = await _context.SystemModules               
                .ToListAsync();

            var selectList = new SelectList(items,
                nameof(SystemModule.SystemModuleId),
                nameof(SystemModule.SystemModuleName),
                selectedId);
            return selectList;
        }


        /// <summary>
        /// Возвращает список планов из документации организаций
        /// </summary>
        /// <param name="organizationDocumentationPlansId"></param>
        /// <returns></returns>
        public async Task<SelectList> GetSelectListOrganizationDocumentationPlansAsync(int selectedId = 0)
        {
            var items = await _context.OrganizationDocumentationPlans
                .Include(p => p.OrganizationDocumentation.Organization)                
                .OrderBy(p => p.OrganizationDocumentation.Organization.OrganizationName)
                .ToListAsync();

            var selectList = new SelectList(items,
                nameof(OrganizationDocumentationPlans.OrganizationDocumentationId),
                nameof(OrganizationDocumentationPlans.OrganizationDocumentationPlansNameFull),
                selectedId);
            return selectList;
        }

        /// <summary>
        /// Возвращает список планов из документации организаций, доступных пользователю
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="selectedId"></param>
        /// <returns></returns>
        public async Task<SelectList> GetSelectListOrganizationDocumentationPlansAsync(string userName,
            int selectedId = 0)
        {
            var organizations = await _appUserRepository.GetAppUserOrganizationsAsync(userName);

            var items = new List<OrganizationDocumentationPlans>();
            foreach (var organization in organizations)
            {
                foreach (var organizationDocumentation in organization.OrganizationDocumentation)
                {
                    items.AddRange(organizationDocumentation.OrganizationDocumentationPlans);
                }
            }            

            var selectList = new SelectList(items,
                nameof(OrganizationDocumentationPlans.OrganizationDocumentationId),
                nameof(OrganizationDocumentationPlans.OrganizationDocumentationPlansNameFull),
                selectedId);
            return selectList;
        }

        /// <summary>
        /// Возвращает список системных ролей
        /// </summary>
        /// <param name="selectedId"></param>
        /// <returns></returns>
        public async Task<SelectList> GetSelectListSystemRolesAsync(int selectedId = 0)
        {
            var items = await _context.SystemRoles
                .OrderBy(sr => sr.SystemRoleName)
                .ToListAsync();

            var selectList = new SelectList(items,
                nameof(SystemRole.SystemRoleId),
                nameof(SystemRole.SystemRoleName),
                selectedId);
            return selectList;
        }

        /// <summary>
        /// Возвращает список привязок модулей к организациям
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="selectedId"></param>
        /// <returns></returns>
        public async Task<SelectList> GetSelectListOrganizationToSystemModulesAsync(int organizationId, int selectedId = 0)
        {
            var items = await _context.OrganizationToSystemModules
                .Include(osm => osm.SystemModule)
                .OrderBy(osm => osm.SystemModule.SystemModuleName)
                .Where(osm => osm.OrganizationId == organizationId)
                .ToListAsync();

            var selectList = new SelectList(items,
                nameof(OrganizationToSystemModule.OrganizationToSystemModuleId),
                "SystemModule.SystemModuleName"/*nameof(OrganizationToSystemModule.SystemModule.SystemModuleName)*/,
                selectedId);
            return selectList;
        }

        /// <summary>
        /// Возвращает список планов из документации текущей организации пользователя
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="organizationDocumentationPlansId"></param>
        /// <returns></returns>
        public async Task<SelectList> GetSelectListCurrentOrganizationDocumentationPlansAsync(string userName,
            int organizationDocumentationPlansId,
            int selectedId = 0)
        {
            var organization = await _appUserRepository.GetCurrentOrganizationAsync(userName);
            organization = await _organizationRepository.GetOrganizationAsync(organization.OrganizationId);

            var items = new List<OrganizationDocumentationPlans>();
            foreach (var organizationDocumentation in organization.OrganizationDocumentation)
            {
                items.AddRange(organizationDocumentation.OrganizationDocumentationPlans);
            }

            var selectList = new SelectList(items,
                nameof(OrganizationDocumentationPlans.OrganizationDocumentationId),
                nameof(OrganizationDocumentationPlans.OrganizationDocumentationPlansNameFull),
                selectedId);
            return selectList;
        }
                

        public static void HieararchyWalk(List<Organization> hierarchy, int level, List<Organization> items)
        {
            if (hierarchy != null)
            {
                foreach (var item in hierarchy)
                {
                    item.OrganizationName = new string('-', level) + item.OrganizationName;
                    items.Add(item);
                    HieararchyWalk(item.ChildOrganizations, level++, items);
                }
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает список зарегистрированных пользователей
        /// </summary>
        /// <param name="selectedId"></param>
        /// <returns></returns>
        public async Task<SelectList> GetSelectListAppUsersAsync(int selectedId = 0)
        {
            var items = await _context.Users.ToListAsync();

            var selectList = new SelectList(items, nameof(AppUser.Id), nameof(AppUser.GetFullName), selectedId);
            return selectList;
        }

        /// <summary>
        /// Возвращает список с/х культур
        /// </summary>
        /// <param name="selectedId"></param>
        /// <returns></returns>
        public async Task<SelectList> GetSelectListCropsAsync(int selectedId = 0)
        {
            var items = await _context.Crops.Include(c => c.CropGroup)
                .OrderBy(c => c.CropGroup.CropGroupName)
                .OrderBy(c => c.CropName)
                .ToListAsync();

            var selectList = new SelectList(items, nameof(Crop.CropId), nameof(Crop.CropName), selectedId);
            return selectList;
        }

        /// <summary>
        /// Возвращает список всех зарегистрированных в системе оросительных систем
        /// </summary>
        /// <param name="selectedId"></param>
        /// <returns></returns>
        public async Task<SelectList> GetSelectListIrrigationSystemsAsync(int selectedId = 0)
        {
            var items = await _context.IrrigationSystems
                .OrderBy(i=>i.IrrigationSystemName)
                .ToListAsync();
            var selectList = new SelectList(items,
                nameof(IrrigationSystem.IrrigationSystemId),
                nameof(IrrigationSystem.IrrigationSystemName),
                selectedId);
            return selectList;
        }

        public async Task<SelectList> GetSelectListIrrigationSystemsAsync(string userName, int selectedId = 0)
        {
            var items = new List<IrrigationSystem>();

            var currentOrganization = await _appUserRepository.GetCurrentOrganizationAsync(userName);

            var organizationToTypeOfActivity = currentOrganization
                .OrganizationToTypeOfActivities
                .FirstOrDefault(ota => ota.TypeOfActivityId == 3);
                        
            foreach (var organizationToTypeOfActivitiesToIrrigationSystem in organizationToTypeOfActivity.OrganizationToTypeOfActivitiesToIrrigationSystems)
            {
                items.Add(organizationToTypeOfActivitiesToIrrigationSystem.IrrigationSystem);
            }
            
            var selectList = new SelectList(items,
                nameof(IrrigationSystem.IrrigationSystemId),
                nameof(IrrigationSystem.IrrigationSystemName),
                selectedId);
            return selectList;
        }

        /// <summary>
        /// Возвращает причины невыполнения чего-либо
        /// </summary>
        /// <returns></returns>
        public async Task<SelectList> GetSelectListReasonsAsync(int selectedId = 0)
        {
            var items = await _context.Reasons
                .OrderBy(r => r.ReasonName)
                .ToListAsync();
            var selectList = new SelectList(items, nameof(Reason.ReasonId), nameof(Reason.ReasonName), selectedId);
            return selectList;
        }
    }
}
