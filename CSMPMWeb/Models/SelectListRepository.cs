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

        public SelectListRepository(MySqlDbContext context,
            IOrganizationRepository organizationRepository)
        {
            _context = context;
            _organizationRepository = organizationRepository;
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
        /// Возвращает список планов из документации организаций
        /// </summary>
        /// <param name="organizationDocumentationPlansId"></param>
        /// <returns></returns>
        public async Task<SelectList> GetSelectListOrganizationDocumentationPlans(int selectedId = 0)
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
        /// Возвращает список с/х культур
        /// </summary>
        /// <param name="selectedId"></param>
        /// <returns></returns>
        public async Task<SelectList> GetSelectListCrops(int selectedId = 0)
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
        public async Task<SelectList> GetSelectListIrrigationSystems(int selectedId = 0)
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

        /// <summary>
        /// Возвращает причины невыполнения чего-либо
        /// </summary>
        /// <returns></returns>
        public async Task<SelectList> GetSelectListReasons(int selectedId = 0)
        {
            var items = await _context.Reasons
                .OrderBy(r => r.ReasonName)
                .ToListAsync();
            var selectList = new SelectList(items, nameof(Reason.ReasonId), nameof(Reason.ReasonName), selectedId);
            return selectList;
        }
    }
}
