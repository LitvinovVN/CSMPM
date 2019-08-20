using System.ComponentModel.DataAnnotations;

namespace CSMPMLib
{
    /// <summary>
    /// Площадь земли в зоне оросительной системы с указанием причины отсутствия полива
    /// </summary>
    public class IrrigationPlanItem_LandAreaNotIrrigationReason
    {
        public int Id { get; set; }

        /// <summary>
        /// Запись плана посева
        /// </summary>
        public int IrrigationPlanItemId { get; set; }
        public IrrigationPlanItem IrrigationPlanItem { get; set; }

        /// <summary>
        /// Площадь земли в зоне оросительной системы, которая не будет поливаться
        /// </summary>
        [Display(Name= "Площадь земли в зоне оросительной системы, которая не будет поливаться, га.")]
        public double Area { get; set; }

        /// <summary>
        /// УИД причины отсутствия полива
        /// </summary>
        [Display(Name = "Причина отсутствия полива")]
        public int ReasonId { get; set; }
        public Reason Reason { get; set; }
    }
}