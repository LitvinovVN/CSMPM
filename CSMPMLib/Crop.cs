using System;
using System.ComponentModel.DataAnnotations;

namespace CSMPMLib
{
    /// <summary>
    /// Сельскохозяйственная культура
    /// </summary>
    public class Crop
    {
        /// <summary>
        /// УИД с/х культуры
        /// </summary>
        public int CropId { get; set; }

        /// <summary>
        /// Наименование с/х культуры
        /// </summary>
        [Display(Name = "Наименование с/х культуры")]
        public string CropName { get; set; }

        /// <summary>
        /// Поливная норма
        /// </summary>
        public double WateringRate { get; set; }

        /// <summary>
        /// Оросительная норма
        /// </summary>
        public double IrrigationRate { get; set; }


        /// <summary>
        /// УИД группы с/х культур
        /// </summary>
        public int CropGroupId { get; set; }

        /// <summary>
        /// Группа с/х культур
        /// </summary>
        public CropGroup CropGroup { get; set; }
    }
}
