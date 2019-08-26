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
                .Include(ao => ao.Organization)
                .Include(ao => ao.AppUser)
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
        /// Возвращает назначение пользователю организации роли при использовании модуля системы
        /// </summary>
        /// <param name="assignedPermissionId"></param>
        /// <returns></returns>
        public async Task<AssignedPermission> GetAssignedPermissionAsync(int assignedPermissionId)
        {
            var entry = await _context.AssignedPermissions
                .Include(ap => ap.AppUserToOrganization.Organization)
                .Include(ap => ap.AppUserToOrganization.AppUser)
                .Include(ap => ap.OrganizationToSystemModule.Organization)
                .Include(ap => ap.OrganizationToSystemModule.SystemModule)
                .Include(ap => ap.SystemRole)
                .FirstOrDefaultAsync(ap => ap.AssignedPermissionId == assignedPermissionId);

            return entry;
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

        
        /// <summary>
        /// Добавляет назначение роли при использовании модуля системы сотруднику организации
        /// </summary>
        /// <param name="assignedPermission"></param>
        /// <returns></returns>
        public async Task AddAssignedPermission(AssignedPermission assignedPermission)
        {
            bool isExists = IsExistsAssignedPermission(assignedPermission);
            if (isExists) return;
            await _context.AssignedPermissions.AddAsync(assignedPermission);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Обновляет назначение роли при использовании модуля системы сотруднику организации
        /// </summary>
        /// <param name="assignedPermission"></param>
        /// <returns></returns>
        public async Task UpdateAssignedPermission(AssignedPermission assignedPermission)
        {
            var sameEntry = await _context.AssignedPermissions
                .FirstOrDefaultAsync(ap => ap.AppUserToOrganizationId == assignedPermission.AppUserToOrganizationId
                && ap.OrganizationToSystemModuleId == assignedPermission.OrganizationToSystemModuleId
                && ap.SystemRoleId == assignedPermission.SystemRoleId);
            if (sameEntry != null)
            {
                _context.AssignedPermissions.Remove(sameEntry);
            }
            
            _context.AssignedPermissions.Update(assignedPermission);
            await _context.SaveChangesAsync();
        }

        
        /// <summary>
        /// Определяет существование объекта привязки "Модуль - Роль" пользователя организации
        /// </summary>
        /// <param name="assignedPermission"></param>
        /// <returns></returns>
        private bool IsExistsAssignedPermission(AssignedPermission assignedPermission)
        {
            return _context.AssignedPermissions
                .Any(ap => ap.AppUserToOrganizationId == assignedPermission.AppUserToOrganizationId
                && ap.OrganizationToSystemModuleId == assignedPermission.OrganizationToSystemModuleId
                && ap.SystemRoleId == assignedPermission.SystemRoleId);
        }

        

        /// <summary>
        /// Удаляет назначение роли при использовании модуля системы сотруднику организации
        /// </summary>
        /// <param name="assignedPermission"></param>
        /// <returns></returns>
        public async Task RemoveAssignedPermission(AssignedPermission assignedPermission)
        {
            _context.AssignedPermissions.Remove(assignedPermission);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Привязывает пользователя к организации
        /// </summary>
        /// <param name="appUserId"></param>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        public async Task BindAppUserToOrganization(string appUserId, int organizationId)
        {
            var entry = await _context.AppUserToOrganizations
                .FirstOrDefaultAsync(auo => auo.AppUserId == appUserId && auo.OrganizationId == organizationId);

            if (entry == null)
            {
                var newBinding = new AppUserToOrganization
                {
                    AppUserId = appUserId,
                    OrganizationId = organizationId
                };

                await _context.AppUserToOrganizations.AddAsync(newBinding);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Удаляет привязку пользователя к организации
        /// </summary>
        /// <param name="appUserToOrganization"></param>
        /// <returns></returns>
        public async Task UnbindAppUserToOrganization(AppUserToOrganization appUserToOrganization)
        {
            _context.AppUserToOrganizations.Remove(appUserToOrganization);
            await _context.SaveChangesAsync();
        }
    }
}
