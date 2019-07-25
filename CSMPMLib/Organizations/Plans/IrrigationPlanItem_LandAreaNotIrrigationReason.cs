namespace CSMPMLib
{
    /// <summary>
    /// Площадь земли в зоне оросительной системы с указанием причины отсутствия полива
    /// </summary>
    public class IrrigationPlanItem_LandAreaNotIrrigationReason
    {
        public int Id { get; set; }

        /// <summary>
        /// Площадь земли в зоне оросительной системы, которая не будет поливаться
        /// </summary>
        public double Area { get; set; }

        /// <summary>
        /// УИД причины отсутствия полива
        /// </summary>
        public int ReasonId { get; set; }
        public Reason Reason { get; set; }
    }
}