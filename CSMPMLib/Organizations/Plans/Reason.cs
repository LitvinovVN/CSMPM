using System.ComponentModel.DataAnnotations;

namespace CSMPMLib
{
    /// <summary>
    /// Причина невыполнения какого-либо мероприятия, действия и т.д.
    /// </summary>
    public class Reason
    {
        public int ReasonId { get; set; }

        [Display(Name = "Наименование причины")]
        public string ReasonName { get; set; }
    }
}