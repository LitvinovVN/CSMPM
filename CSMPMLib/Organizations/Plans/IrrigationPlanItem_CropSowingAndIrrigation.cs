using System.ComponentModel.DataAnnotations;

namespace CSMPMLib
{
    /// <summary>
    /// С/х культура - посев - полив
    /// </summary>
    public class IrrigationPlanItem_CropSowingAndIrrigation
    {
        public int IrrigationPlanItem_CropSowingAndIrrigationId { get; set; }

        /// <summary>
        /// Запись плана посева
        /// </summary>
        public int IrrigationPlanItemId { get; set; }
        public IrrigationPlanItem IrrigationPlanItem { get; set; }

        /// <summary>
        /// С/х культура
        /// </summary>
        [Display(Name = "Наименование с/х культуры")]
        public int CropId { get; set; }
        public Crop Crop { get; set; }

        /// <summary>
        /// Посев, га
        /// </summary>
        [Display(Name = "Посев, га")]
        public double Sowing { get; set; }

        /// <summary>
        /// Полив, га
        /// </summary>
        [Display(Name = "Полив, га")]
        public double Irrigation { get; set; }
    }
}