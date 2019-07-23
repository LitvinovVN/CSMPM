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
    }
}
