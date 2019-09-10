using CSMPMLib.ElectricitySupply;
using CSMPMWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMPMWeb.Controllers
{
    public class VirtualLabs : Controller
    {
        SelectListRepository _selectListRepository;

        public VirtualLabs(SelectListRepository selectListRepository)
        {
            _selectListRepository = selectListRepository;
        }

        public IActionResult TransformerDUSelection()
        {
            ViewBag.p1_tp6_100 = 10_000;
            ViewBag.p1_tp6_25 = 10_000;
            ViewBag.p1_tp2_100 = 10_000;
            ViewBag.p1_tp2_25 = 10_000;

            ViewBag.p2_tp6_100 = 9_980;
            ViewBag.p2_tp6_25 = 9_980;
            ViewBag.p2_tp2_100 = 9_995;
            ViewBag.p2_tp2_25 = 9_990;

            ViewBag.p3_tp6_100 = 9_950;
            ViewBag.p3_tp6_25 = 9_950;

            ViewBag.p4_tp6_100 = 9_800;
            ViewBag.p4_tp6_25 = 9_850;

            ViewBag.p5_tp6_100 = 9_750;
            ViewBag.p5_tp6_25 = 9_785;

            ViewBag.p6_tp6_100 = 9_700;
            ViewBag.p6_tp6_25 = 9_750;

            ViewBag.pa_tp6_100 = 385;
            ViewBag.pa_tp6_25 = 388;
            ViewBag.pa_tp2_100 = 395;
            ViewBag.pa_tp2_25 = 398;

            ViewBag.pb_tp6_100 = 360;
            ViewBag.pb_tp6_25 = 380;
            ViewBag.pb_tp2_100 = 380;
            ViewBag.pb_tp2_25 = 385;

            ViewBag.Tp2_nadb_reg = 0;
            ViewBag.Tp6_nadb_reg = 0;                

            return View();
        }

        [HttpPost]
        public IActionResult TransformerDUSelection(double p1_tp6_100, double p1_tp6_25, double p1_tp2_100, double p1_tp2_25,
            double p2_tp6_100, double p2_tp6_25, double p2_tp2_100, double p2_tp2_25,
            double p3_tp6_100, double p3_tp6_25, 
            double p4_tp6_100, double p4_tp6_25, 
            double p5_tp6_100, double p5_tp6_25, 
            double p6_tp6_100, double p6_tp6_25, 
            double pa_tp6_100, double pa_tp6_25, double pa_tp2_100, double pa_tp2_25,
            double pb_tp6_100, double pb_tp6_25, double pb_tp2_100, double pb_tp2_25,
            double tp2_nadb_reg, double tp6_nadb_reg)
        {
            ViewBag.p1_tp6_100 = p1_tp6_100;
            ViewBag.p1_tp6_25  = p1_tp6_25;
            ViewBag.p1_tp2_100 = p1_tp2_100;
            ViewBag.p1_tp2_25  = p1_tp2_25;

            ViewBag.p2_tp6_100 = p2_tp6_100;
            ViewBag.p2_tp6_25  = p2_tp6_25;
            ViewBag.p2_tp2_100 = p2_tp2_100;
            ViewBag.p2_tp2_25  = p2_tp2_25;

            ViewBag.p3_tp6_100 = p3_tp6_100;
            ViewBag.p3_tp6_25  = p3_tp6_25;            

            ViewBag.p4_tp6_100 = p4_tp6_100;
            ViewBag.p4_tp6_25  = p4_tp6_25;

            ViewBag.p5_tp6_100 = p5_tp6_100;
            ViewBag.p5_tp6_25  = p5_tp6_25;

            ViewBag.p6_tp6_100 = p6_tp6_100;
            ViewBag.p6_tp6_25  = p6_tp6_25;

            ViewBag.pa_tp6_100 = pa_tp6_100;
            ViewBag.pa_tp6_25  = pa_tp6_25;
            ViewBag.pa_tp2_100 = pa_tp2_100;
            ViewBag.pa_tp2_25  = pa_tp2_25;

            ViewBag.pb_tp6_100 = pb_tp6_100;
            ViewBag.pb_tp6_25  = pb_tp6_25;
            ViewBag.pb_tp2_100 = pb_tp2_100;
            ViewBag.pb_tp2_25  = pb_tp2_25;


            ViewBag.dU1_tp6_100 = ElectricitySupplyCalculations.GetVoltageDeviation(p1_tp6_100);
            ViewBag.dU1_tp6_25  = ElectricitySupplyCalculations.GetVoltageDeviation(p1_tp6_25);
            ViewBag.dU1_tp2_100 = ElectricitySupplyCalculations.GetVoltageDeviation(p1_tp2_100);
            ViewBag.dU1_tp2_25  = ElectricitySupplyCalculations.GetVoltageDeviation(p1_tp2_25);

            ViewBag.dU12_tp6_100 = ElectricitySupplyCalculations.GetVoltageLoss(p2_tp6_100, p1_tp6_100);
            ViewBag.dU12_tp6_25  = ElectricitySupplyCalculations.GetVoltageLoss(p2_tp6_25, p1_tp6_25);
            ViewBag.dU12_tp2_100 = ElectricitySupplyCalculations.GetVoltageLoss(p2_tp2_100, p1_tp2_100);
            ViewBag.dU12_tp2_25  = ElectricitySupplyCalculations.GetVoltageLoss(p2_tp2_25, p1_tp2_25);

            ViewBag.dU23_tp6_100 = ElectricitySupplyCalculations.GetVoltageLoss(p3_tp6_100, p2_tp6_100);
            ViewBag.dU23_tp6_25  = ElectricitySupplyCalculations.GetVoltageLoss(p3_tp6_25, p2_tp6_25);

            ViewBag.dU34_tp6_100 = ElectricitySupplyCalculations.GetVoltageLoss(p4_tp6_100, p3_tp6_100);
            ViewBag.dU34_tp6_25  = ElectricitySupplyCalculations.GetVoltageLoss(p4_tp6_25, p3_tp6_25);

            ViewBag.dU45_tp6_100 = ElectricitySupplyCalculations.GetVoltageLoss(p5_tp6_100, p4_tp6_100);
            ViewBag.dU45_tp6_25  = ElectricitySupplyCalculations.GetVoltageLoss(p5_tp6_25, p4_tp6_25);

            ViewBag.dU56_tp6_100 = ElectricitySupplyCalculations.GetVoltageLoss(p6_tp6_100, p5_tp6_100);
            ViewBag.dU56_tp6_25  = ElectricitySupplyCalculations.GetVoltageLoss(p6_tp6_25, p5_tp6_25);


            ViewBag.Tp2_nadb_reg = tp2_nadb_reg;
            ViewBag.Tp6_nadb_reg = tp6_nadb_reg;

            ViewBag.Tp2_VoltageLoss_100 = ElectricitySupplyCalculations.GetTpVoltageLoss(p2_tp2_100, pa_tp2_100, 5 + tp2_nadb_reg);
            ViewBag.Tp2_VoltageLoss_25  = ElectricitySupplyCalculations.GetTpVoltageLoss(p2_tp2_25,  pa_tp2_25,  5 + tp2_nadb_reg);
            ViewBag.Tp6_VoltageLoss_100 = ElectricitySupplyCalculations.GetTpVoltageLoss(p6_tp6_100, pa_tp6_100, 5 + tp6_nadb_reg);
            ViewBag.Tp6_VoltageLoss_25  = ElectricitySupplyCalculations.GetTpVoltageLoss(p6_tp6_25,  pa_tp6_25,  5 + tp6_nadb_reg);

            ViewBag.dUab_tp6_100 = ElectricitySupplyCalculations.GetVoltageLoss(pb_tp6_100, pa_tp6_100, 380);
            ViewBag.dUab_tp6_25  = ElectricitySupplyCalculations.GetVoltageLoss(pb_tp6_25,  pa_tp6_25, 380);
            ViewBag.dUab_tp2_100 = ElectricitySupplyCalculations.GetVoltageLoss(pb_tp2_100, pa_tp2_100, 380);
            ViewBag.dUab_tp2_25  = ElectricitySupplyCalculations.GetVoltageLoss(pb_tp2_25,  pa_tp2_25, 380);

            ViewBag.dUb_tp6_100 = ElectricitySupplyCalculations.GetVoltageDeviation(pb_tp6_100, 380);
            ViewBag.dUb_tp6_25  = ElectricitySupplyCalculations.GetVoltageDeviation(pb_tp6_25, 380);
            ViewBag.dUb_tp2_100 = ElectricitySupplyCalculations.GetVoltageDeviation(pb_tp2_100, 380);
            ViewBag.dUb_tp2_25  = ElectricitySupplyCalculations.GetVoltageDeviation(pb_tp2_25, 380);

            return View();
        }
    }
}
