using CSMPMLib.ElectricitySupply;
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

        [HttpPost]
        public IActionResult TransformerDUSelection(double p2_tp6_100, double p2_tp6_25, double p2_tp2_100, double p2_tp2_25,
            double p3_tp6_100, double p3_tp6_25, double p3_tp2_100, double p3_tp2_25,
            double p4_tp6_100, double p4_tp6_25, double p4_tp2_100, double p4_tp2_25,
            double p5_tp6_100, double p5_tp6_25, double p5_tp2_100, double p5_tp2_25,
            double p6_tp6_100, double p6_tp6_25, double p6_tp2_100, double p6_tp2_25,
            double pa_tp6_100, double pa_tp6_25, double pa_tp2_100, double pa_tp2_25,
            double pb_tp6_100, double pb_tp6_25, double pb_tp2_100, double pb_tp2_25)
        {
            ViewBag.dU23_tp6_100 = ElectricitySupplyCalculations.GetVoltageLoss(p3_tp6_100, p2_tp6_100);
            ViewBag.dU23_tp6_25  = ElectricitySupplyCalculations.GetVoltageLoss(p3_tp6_25,  p2_tp6_25);
            ViewBag.dU23_tp2_100 = ElectricitySupplyCalculations.GetVoltageLoss(p3_tp2_100, p2_tp2_100);
            ViewBag.dU23_tp2_25  = ElectricitySupplyCalculations.GetVoltageLoss(p3_tp2_25,  p2_tp2_25);

            ViewBag.dU34_tp6_100 = ElectricitySupplyCalculations.GetVoltageLoss(p4_tp6_100, p3_tp6_100);
            ViewBag.dU34_tp6_25  = ElectricitySupplyCalculations.GetVoltageLoss(p4_tp6_25,  p3_tp6_25);
            ViewBag.dU34_tp2_100 = ElectricitySupplyCalculations.GetVoltageLoss(p4_tp2_100, p3_tp2_100);
            ViewBag.dU34_tp2_25  = ElectricitySupplyCalculations.GetVoltageLoss(p4_tp2_25,  p3_tp2_25);

            ViewBag.dU45_tp6_100 = ElectricitySupplyCalculations.GetVoltageLoss(p5_tp6_100, p4_tp6_100);
            ViewBag.dU45_tp6_25  = ElectricitySupplyCalculations.GetVoltageLoss(p5_tp6_25,  p4_tp6_25);
            ViewBag.dU45_tp2_100 = ElectricitySupplyCalculations.GetVoltageLoss(p5_tp2_100, p4_tp2_100);
            ViewBag.dU45_tp2_25  = ElectricitySupplyCalculations.GetVoltageLoss(p5_tp2_25,  p4_tp2_25);

            ViewBag.dU56_tp6_100 = ElectricitySupplyCalculations.GetVoltageLoss(p6_tp6_100, p5_tp6_100);
            ViewBag.dU56_tp6_25  = ElectricitySupplyCalculations.GetVoltageLoss(p6_tp6_25,  p5_tp6_25);
            ViewBag.dU56_tp2_100 = ElectricitySupplyCalculations.GetVoltageLoss(p6_tp2_100, p5_tp2_100);
            ViewBag.dU56_tp2_25  = ElectricitySupplyCalculations.GetVoltageLoss(p6_tp2_25,  p5_tp2_25);

            ViewBag.p2_tp6_100 = p2_tp6_100;
            ViewBag.p2_tp6_25 = p2_tp6_25;
            ViewBag.p2_tp2_100 = p2_tp2_100;
            ViewBag.p2_tp2_25 = p2_tp2_25;

            ViewBag.p3_tp6_100 = p3_tp6_100;
            ViewBag.p3_tp6_25 = p3_tp6_25;
            ViewBag.p3_tp2_100 = p3_tp2_100;
            ViewBag.p3_tp2_25 = p3_tp2_25;

            ViewBag.p4_tp6_100 = p4_tp6_100;
            ViewBag.p4_tp6_25 = p4_tp6_25;
            ViewBag.p4_tp2_100 = p4_tp2_100;
            ViewBag.p4_tp2_25 = p4_tp2_25;

            ViewBag.p5_tp6_100 = p5_tp6_100;
            ViewBag.p5_tp6_25 = p5_tp6_25;
            ViewBag.p5_tp2_100 = p5_tp2_100;
            ViewBag.p5_tp2_25 = p5_tp2_25;

            ViewBag.p6_tp6_100 = p6_tp6_100;
            ViewBag.p6_tp6_25 = p6_tp6_25;
            ViewBag.p6_tp2_100 = p6_tp2_100;
            ViewBag.p6_tp2_25 = p6_tp2_25;

            ViewBag.pa_tp6_100 = pa_tp6_100;
            ViewBag.pa_tp6_25 = pa_tp6_25;
            ViewBag.pa_tp2_100 = pa_tp2_100;
            ViewBag.pa_tp2_25 = pa_tp2_25;

            ViewBag.pb_tp6_100 = pb_tp6_100;
            ViewBag.pb_tp6_25 = pb_tp6_25;
            ViewBag.pb_tp2_100 = pb_tp2_100;
            ViewBag.pb_tp2_25 = pb_tp2_25;

            return View();
        }
    }
}
