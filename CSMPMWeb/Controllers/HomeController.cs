using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSMPMWeb.Models;
using CSMPMLib;

namespace CSMPMWeb.Controllers
{
    public class HomeController : Controller
    {
        MySqlDbContext _context;

        public HomeController(MySqlDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            Class1 c1 = new Class1();
            ViewBag.c1 = c1;
            ViewBag.Roles = _context.Roles.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SystemUpdate()
        {
            var process = new Process();
            process.EnableRaisingEvents = true; // to avoid [defunct] sh processes
            process.StartInfo.FileName = "/var/CSMPM/update.sh";
            process.StartInfo.Arguments = "";
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit(10000);
            if (process.HasExited)
            {
                Console.WriteLine("Exit code: " + process.ExitCode);
            }
            else
            {
                Console.WriteLine("Child process still running after 10 seconds");
            }

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
