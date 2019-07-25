namespace CSMPMLib
{
    /// <summary>
    /// Площадь земли не сх назначения в зоне оросительной системы с причиной не сх использования
    /// </summary>
    public class IrrigationPlanItem_LandAreaNotAgriculturalReason
    {
        public int Id { get; set; }

        /// <summary>
        /// Площадь земли не сх назначения в зоне оросительной системы с причиной не сх использования
        /// </summary>
        public double Area { get; set; }

        /// <summary>
        /// УИД причины неиспользования земли для сх
        /// </summary>
        public int ReasonId { get; set; }
        public Reason Reason { get; set; }
    }
}