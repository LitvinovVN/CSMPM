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
        public int CropId { get; set; }
        public Crop Crop { get; set; }

        /// <summary>
        /// Посев, га
        /// </summary>
        public double Sowing { get; set; }

        /// <summary>
        /// Полив, га
        /// </summary>
        public double Irrigation { get; set; }
    }
}