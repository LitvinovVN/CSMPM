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
        /// УИД оросительного канала, к которому привязана точки
        /// </summary>
        public int? IrrigationCanalId { get; set; }

        [Display(Name = "Оросительный канал")]
        public IrrigationCanal IrrigationCanal { get; set; }

        // Добавить координаты присоединения
        // широта, долгота, высота?

        // Тип присоединения? Способ присоединения? Технические средства?


    }
}