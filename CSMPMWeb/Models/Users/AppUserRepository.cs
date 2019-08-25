using CSMPMLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMPMWeb.Models
{
    /// <summary>
    /// Репозиторий пользователей системы
    /// </summary>
    public class AppUserRepository
    {
        MySqlDbContext _context;

        public AppUserRepository(MySqlDbContext context)
        {
            _context = context;
        }

        IIncludableQueryable<AppUserToOrganization, SystemRole> GetAppUserToOrganizations
        {
            get
            {
                return _context.AppUserToOrganizations
                        .Include(a => a.AppUser)
                        .Include(a => a.Organization)
                        .ThenInclude(o => o.OrganizationToTypeOfActivities)
                        .ThenInclude(ot => ot.OrganizationToTypeOfActivitiesToIrrigationSystems)
                        .ThenInclude(oti => oti.IrrigationSystem)
                        .Include(a => a.AssignedPermissions)
                        .ThenInclude(p => p.OrganizationToSystemModule.SystemModule)
                        .Include(a => a.AssignedPermissions)
                        .ThenInclude(p => p.SystemRole);
            }
        }

        /// <summary>
        /// Возвращает привязки пользователя к организациям
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<List<AppUserToOrganization>> GetAppUserToOrganizationsAsync(string userName)
        {
            var userId = GetAppUserId(userName);            

            var items = await GetAppUserToOrganizations
                .Where(a => a.AppUser.UserName == userName)
                .ToListAsync();

            return items;
        }

        /// <summary>
        /// Возвращает привязки пользователей к указанной организации 
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        public async Task<List<AppUserToOrganization>> GetAppUserToOrganizationsAsync(int organizationId)
        {
            var items = await GetAppUserToOrganizations
                .Where(a => a.OrganizationId == organizationId)
                .ToListAsync();

            return items;
        }

        public string GetAppUserId(string userName)
        {
            var appUser = _context.Users
                .FirstOrDefault(u => u.UserName == userName);
            return appUser.Id;
        }

        /// <summary>
        /// Возвращает полностью заполненный объект пользователя
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<AppUser> GetAppUserAsync(string userName)
        {
            var appUser = await _context.Users
                .Include(u => u.AppUserToOrganizationWithAppUserPermissions)
                    .ThenInclude(a => a.Organization)
                        .ThenInclude(o => o.OrganizationDocumentation)
                            .ThenInclude(od => od.OrganizationDocumentationPlans)
                .Include(u => u.AppUserToOrganizationWithAppUserPermissions)
                    .ThenInclude(a => a.AssignedPermissions)
                        .ThenInclude(p => p.OrganizationToSystemModule)
                .Include(u => u.AppUserToOrganizationWithAppUserPermissions)
                    .ThenInclude(a => a.AssignedPermissions)
                        .ThenInclude(p => p.SystemRole)
                .FirstOrDefaultAsync(u=>u.UserName == userName);

            return appUser;
        }

        /// <summary>
        /// Назначает текущую организацию для пользователя
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="id"></param>
        public async Task SelectCurrentOrganizationAsync(string userName, int id)
        {
            var appUserToOrganizations = await GetAppUserToOrganizationsAsync(userName);

            bool isChanged = false;
            foreach (var appUserToOrganization in appUserToOrganizations)
            {
                if(appUserToOrganization.AppUserToOrganizationId == id)
                {
                    appUserToOrganization.IsUserSelectedAsCurrent = true;
                    isChanged = true;
                }
            }

            if(isChanged)
            {
                foreach (var appUserToOrganization in appUserToOrganizations)
                {
                    if (appUserToOrganization.AppUserToOrganizationId != id)
                    {
                        appUserToOrganization.IsUserSelectedAsCurrent = false;                        
                    }
                }
            }

            _context.SaveChanges();
        }

        /// <summary>
        /// Возвращает объект привязки пользователя к организации
        /// </summary>
        /// <param name="appUserToOrganizationId"></param>
        /// <returns></returns>
        public async Task<AppUserToOrganization> GetAppUserToOrganizationAsync(int appUserToOrganizationId)
        {
            var result = await GetAppUserToOrganizations
                .FirstOrDefaultAsync(ao => ao.AppUserToOrganizationId == appUserToOrganizationId);
            return result;
        }

        /// <summary>
        /// Возвращает организации, доступные пользователю
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<List<Organization>> GetAppUserOrganizationsAsync(string userName)
        {
            List<Organization> result = new List<Organization>();
            var appUserToOrganizations = (await GetAppUserAsync(userName)).AppUserToOrganizationWithAppUserPermissions;
            foreach (var appUserToOrganization in appUserToOrganizations)
            {
                result.Add(appUserToOrganization.Organization);
            }
            return result;
        }
                

        /// <summary>
        /// Возвращает текущую выбранную пользователем организацию
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<Organization> GetCurrentOrganizationAsync(string userName)
        {
            return (await GetAppUserToOrganizationsAsync(userName))
                .FirstOrDefault(o => o.IsUserSelectedAsCurrent)
                .Organization;
        }
    }
}
