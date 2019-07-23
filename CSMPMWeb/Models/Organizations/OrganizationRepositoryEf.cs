using CSMPMLib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMPMWeb.Models
{
    /// <summary>
    /// Репозиторий EF организаций
    /// </summary>
    public class OrganizationRepositoryEf : IOrganizationRepository
    {
        MySqlDbContext _context;

        public OrganizationRepositoryEf(MySqlDbContext context)
        {
            _context = context;
        }

        public async Task<Organization> AddOrganizationAsync(Organization organization)
        {
            throw new NotImplementedException();
        }

        public async Task<Organization> GetOrganizationAsync(int organizationId)
        {
            var organizations = await _context.Organizations.ToListAsync();
            var organization = organizations
                .FirstOrDefault(o => o.OrganizationId == organizationId);
            
            return organization;
        }

        public async Task<List<Organization>> GetOrganizationsAsync(HierarchyLoadModesEnum hierarchyLoadModes = HierarchyLoadModesEnum.FullHierarchy)
        {
            var organizations = new List<Organization>();

            switch (hierarchyLoadModes)
            {
                case HierarchyLoadModesEnum.RootElements:
                    organizations = await _context.Organizations
                        .Where(o => o.ParentOrganizationId == null)
                        .ToListAsync();
                    break;
                default: // HierarchyLoadModesEnum.FullHierarchy
                    organizations = await _context.Organizations.ToListAsync();
                    break;
            }                       
                                                
            return organizations;
        }

        public async Task RemoveOrganizationAsync(Organization organization)
        {
            _context.Organizations.Remove(organization);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrganizationAsync(Organization organization)
        {
            _context.Update(organization);
            await _context.SaveChangesAsync();
        }
    }
}
