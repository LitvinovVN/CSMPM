using CSMPMWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMPMWeb.Components
{
    public class UserAccountViewComponent : ViewComponent
    {
        AppUserRepository _appUserRepository;

        public UserAccountViewComponent(AppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var appUser = await _appUserRepository.GetAppUserAsync(User.Identity.Name);

            return View(appUser);
        }
    }
}
