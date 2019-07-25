using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSMPMLib
{
    /// <summary>
    /// План полива. Модель записи.
    /// </summary>
    public class IrrigationPlanItem
    {
        public int IrrigationPlanItemId { get; set; }

        public int IrrigationPlanId { get; set; }
        public IrrigationPlan IrrigationPlan { get; set; }

        /// <summary>
        /// Оросительная система, для которой формируется запись плана полива
        /// </summary>        
        [Display(Name = "Оросительная система")]
        public string IrrigationSystemName { get; set; }

        /// <summary>
        /// Наличие земельной площади на начало года
        /// </summary>
        public double LandAreaOnBeginningOfYear { get; set; }

        /// <summary>
        /// Наличие земельной площади с/х назначения
        /// (сельхоз. использовано)
        /// </summary>
        public double LandAreaAgriculturalUse { get; set; }

        /// <summary>
        /// Земельная площадь, включённая в план полива
        /// (включено в план полива)
        /// </summary>
        public double LandAreaIncludedInIrrigationPlan { get; set; }

        /// <summary>
        /// Земельная площадь, включённая в план посева
        /// (посевная площадь)
        /// </summary>
        public double LandAreaSowing { get; set; }

        /// <summary>
        /// Таблица "С/х культура - посев - полив"
        /// </summary>
        public List<IrrigationPlanItem_CropSowingAndIrrigation> IrrigationPlanItem_CropSowingAndIrrigations { get; set; }

        /// <summary>
        /// Площади земель не сх назначения в зоне оросительной системы с причиной не сх использования
        /// </summary>
        public List<IrrigationPlanItem_LandAreaNotAgriculturalReason> IrrigationPlanItem_LandAreaNotAgriculturalReasons { get; set; }

        /// <summary>
        /// Площади земель в зоне оросительной системы, которые не будут поливаться, с причиной отсутствия полива
        /// </summary>
        public List<IrrigationPlanItem_LandAreaNotIrrigationReason> IrrigationPlanItem_LandAreaNotIrrigationReasons { get; set; }
    }
}