using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMPMWeb.Models
{
    /// <summary>
    /// Модель представления для редактирования ролей пользователя
    /// </summary>
    public class AppUserEditRolesViewModel
    {
        public AppUser AppUser { get; set; }
                
        public List<AppUserEditRolesViewModelLine> Roles { get; set; } = new List<AppUserEditRolesViewModelLine>();

        public AppUserEditRolesViewModel()
        {

        }

        public AppUserEditRolesViewModel(AppUser appUser, List<IdentityRole> roles, IList<string> userRoles)
        {
            AppUser = appUser;

            foreach (var role in roles)
            {
                bool r = userRoles.Contains(role.Name);

                var newLine = new AppUserEditRolesViewModelLine();
                newLine.RoleName = role.Name;
                newLine.IsInRole = r;
                newLine.IsInRole_Edited = r;
                Roles.Add(newLine);
            }
        }
    }        
}
