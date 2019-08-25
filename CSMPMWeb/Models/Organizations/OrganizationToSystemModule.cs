using CSMPMLib;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSMPMWeb.Models
{
    /// <summary>
    /// Сопоставление организации и вида деятельности
    /// </summary>
    public class OrganizationToSystemModule
    {
        public int OrganizationToSystemModuleId { get; set; }

        [Display(Name = "Организация")]
        public int OrganizationId { get; set; }
        [Display(Name = "Организация")]
        public Organization Organization { get; set; }

        [Display(Name = "Модуль системы")]
        public int SystemModuleId { get; set; }
        [Display(Name = "Модуль системы")]
        public SystemModule SystemModule { get; set; }
    }
}