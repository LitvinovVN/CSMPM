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
        [Display(Name = "Поливная норма")]
        public double WateringRate { get; set; }

        /// <summary>
        /// Оросительная норма
        /// </summary>
        [Display(Name = "Оросительная норма")]
        public double IrrigationRate { get; set; }


        /// <summary>
        /// УИД группы с/х культур
        /// </summary>
        [Display(Name = "Группа с/х культур")]
        public int CropGroupId { get; set; }

        /// <summary>
        /// Группа с/х культур
        /// </summary>
        [Display(Name = "Группа с/х культур")]
        public CropGroup CropGroup { get; set; }
    }
}
