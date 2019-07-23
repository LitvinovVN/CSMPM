using System.ComponentModel.DataAnnotations;

namespace CSMPMLib
{
    /// <summary>
    /// Справочник типов сопоставления организации и технической системы
    /// </summary>
    public class OrganizationToSystemRelationType
    {
        public int Id { get; set; }

        [Display(Name = "Наименование сопоставления организации и технической системы")]
        public string Name { get; set; }
    }
}