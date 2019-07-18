using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMPMWeb.Components
{
    public class UserAccountViewComponent : ViewComponent
    {
        public UserAccountViewComponent()
        {

        }

        public IViewComponentResult Invoke()
        {
            string userName = User.Identity.Name;

            return View((object)userName);
        }
    }
}
