using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSMPMLib
{
    /// <summary>
    /// Точка присоединения к оросительной сети
    /// </summary>
    public class IrrigationCanalConnectionPoint
    {
        /// <summary>
        /// УИД точки присоединения к оросительной сети
        /// </summary>
        public int IrrigationCanalConnectionPointId { get; set; }

        /// <summary>
        /// Наименование точки присоединения к оросительной сети
        /// </summary>
        [Display(Name = "Наименование точки присоединения к оросительной сети")]
        public string IrrigationCanalConnectionPointName { get; set; }
               
        /// <summary>
        /// Связующая таблица для хранения принадлежности точки присоединения оросительным каналам с указанием типа принадлежности
        /// </summary>
        [Display(Name = "Оросительный канал")]
        public List<IrrigationCanalConnectionPointToIrrigationCanal> IrrigationCanalConnectionPointToIrrigationCanal { get; set; }

        // Добавить координаты присоединения
        // широта, долгота, высота?

        // Тип присоединения? Способ присоединения? Технические средства?


    }
}