using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSMPMLib
{
    /// <summary>
    /// Оросительный канал
    /// </summary>
    public class IrrigationCanal
    {
        /// <summary>
        /// УИД оросительного канала
        /// </summary>
        public int IrrigationCanalId { get; set; }

        /// <summary>
        /// Оросительный канал
        /// </summary>
        [Display(Name = "Оросительный канал")]
        public string IrrigationCanalName { get; set; }

        /// <summary>
        /// УИД оросительной сети, которой принадлежит канал
        /// </summary>
        [Display(Name = "Оросительная сеть")]
        public int IrrigationGridId { get; set; }

        /// <summary>
        /// Оросительная сеть, которой принадлежит канал
        /// </summary>
        [Display(Name = "Оросительная сеть")]
        public IrrigationGrid IrrigationGrid { get; set; }

        // Разработать модель сети каналов
        ///// <summary>
        ///// Точка присоединения к оросительной сети
        ///// </summary>
        //[Display(Name = "Точка присоединения")]
        //public int IrrigationCanalConnectionPointId { get; set; }

        ///// <summary>
        ///// Точка присоединения к оросительной сети
        ///// </summary>
        //[Display(Name = "Точка присоединения")]
        //public IrrigationCanalConnectionPoint IrrigationCanalConnectionPoint { get; set; }

        ///// <summary>
        ///// Точки присоединения потребителей воды к оросительному каналу
        ///// </summary>
        //public List<IrrigationCanalConnectionPoint> IrrigationCanalConnectionPoints { get; set; }
    }
}
