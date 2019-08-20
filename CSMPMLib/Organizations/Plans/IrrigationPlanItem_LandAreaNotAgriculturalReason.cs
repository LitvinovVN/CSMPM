using System.ComponentModel.DataAnnotations;

namespace CSMPMLib
{
    /// <summary>
    /// Площадь земли не сх назначения в зоне оросительной системы с причиной не сх использования
    /// </summary>
    public class IrrigationPlanItem_LandAreaNotAgriculturalReason
    {
        public int Id { get; set; }

        /// <summary>
        /// Запись плана посева
        /// </summary>
        public int IrrigationPlanItemId { get; set; }
        public IrrigationPlanItem IrrigationPlanItem { get; set; }

        /// <summary>
        /// Площадь земли не сх назначения в зоне оросительной системы с причиной не сх использования
        /// </summary>
        [Display(Name = "Площадь земли не сх назначения в зоне оросительной системы с причиной не сх использования")]
        public double Area { get; set; }

        /// <summary>
        /// УИД причины неиспользования земли для сх
        /// </summary>
        [Display(Name = "Причина отсутствия полива")]
        public int ReasonId { get; set; }
        public Reason Reason { get; set; }
    }
}