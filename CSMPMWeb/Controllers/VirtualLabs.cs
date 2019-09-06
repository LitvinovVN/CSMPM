using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMPMWeb.Controllers
{
    public class VirtualLabs : Controller
    {
        public IActionResult TransformerDUSelection()
        {
            return View();
        }
    }
}
