using System.ComponentModel.DataAnnotations;

namespace CSMPMLib
{
    /// <summary>
    /// Тип присоединения точки к оросительному каналу
    /// </summary>
    public class IrrigationCanalConnectionPointType
    {
        public int Id {get;set;}

        [Display(Name = "Тип присоединения точки к оросительному каналу")]
        public string Name { get; set; }
    }
}