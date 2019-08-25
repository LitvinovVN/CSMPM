using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSMPMWeb.Models
{
    public static class InitDatabaseUserData
    {
        /// <summary>
        /// Создание учётных записей пользователей
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static async Task CreateUserData(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                UserManager<AppUser> userManager = serviceScope.ServiceProvider.GetService<UserManager<AppUser>>();
                RoleManager<IdentityRole> roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();                
                                
                string role = "Пользователи";

                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }

                // 1
                string username = "testUser1";
                string email = "testUser1@example.com";
                string password = "test1";

                if (await userManager.FindByNameAsync(username) == null)
                {
                    AppUser user = new AppUser
                    {
                        UserName = username,
                        Email = email,
                        FirstName = "Иван",
                        Patronymic = "Иванович",
                        LastName = "Иванов",
                        AppUserToOrganizationWithAppUserPermissions = new List<AppUserToOrganization>
                        {
                             new AppUserToOrganization
                             {
                                  OrganizationId = 1, AssignedPermissions = new List<AssignedPermission>
                                  {
                                      new AssignedPermission{ OrganizationToSystemModuleId = 1, SystemRoleId = 1}
                                  }
                             },
                             new AppUserToOrganization
                             {
                                 OrganizationId = 2,
                                 AssignedPermissions = new List<AssignedPermission>
                                 {
                                      new AssignedPermission{ OrganizationToSystemModuleId = 1, SystemRoleId = 2}
                                 },
                                 IsUserSelectedAsCurrent = true
                             }
                        }
                    };
                    IdentityResult result = await userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {                        
                        await userManager.AddToRoleAsync(user, role);
                    }
                }

                // 2               
                username = "testUser2";
                email = "testUser2@example.com";
                password = "test2";

                if (await userManager.FindByNameAsync(username) == null)
                {
                    AppUser user = new AppUser
                    {
                        UserName = username,
                        Email = email,
                        FirstName = "Пётр",
                        Patronymic = "Петрович",
                        LastName = "Петров",
                        AppUserToOrganizationWithAppUserPermissions = new List<AppUserToOrganization>
                        {
                             new AppUserToOrganization
                             {
                                  OrganizationId = 1, AssignedPermissions = new List<AssignedPermission>
                                  {
                                      new AssignedPermission{ OrganizationToSystemModuleId = 1, SystemRoleId = 2}
                                  }
                             },
                             new AppUserToOrganization
                             {
                                  OrganizationId = 3, AssignedPermissions = new List<AssignedPermission>
                                  {
                                      new AssignedPermission{ OrganizationToSystemModuleId = 1, SystemRoleId = 1}
                                  }
                             }
                        }
                    };
                    IdentityResult result = await userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, role);
                    }
                }

                // 3
                username = "testUser3";
                email = "testUser3@example.com";
                password = "test3";

                if (await userManager.FindByNameAsync(username) == null)
                {
                    AppUser user = new AppUser
                    {
                        UserName = username,
                        Email = email,
                        FirstName = "Николай",
                        Patronymic = "Николаевич",
                        LastName = "Николаев",
                        AppUserToOrganizationWithAppUserPermissions = new List<AppUserToOrganization>
                        {
                             new AppUserToOrganization
                             {
                                  OrganizationId = 1, AssignedPermissions = new List<AssignedPermission>
                                  {
                                      new AssignedPermission{ OrganizationToSystemModuleId = 1, SystemRoleId = 2}
                                  }
                             },
                             new AppUserToOrganization
                             {
                                  OrganizationId = 3, AssignedPermissions = new List<AssignedPermission>
                                  {
                                      new AssignedPermission{ OrganizationToSystemModuleId = 1, SystemRoleId = 2}
                                  }
                             }
                        }
                    };
                    IdentityResult result = await userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, role);
                    }
                }
            }
        }
    }
}