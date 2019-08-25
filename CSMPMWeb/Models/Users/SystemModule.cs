using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSMPMWeb.Models
{
    /// <summary>
    /// Модуль системы
    /// </summary>
    public class SystemModule
    {
        /// <summary>
        /// УИД модуля системы
        /// </summary>
        public int SystemModuleId { get; set; }

        /// <summary>
        /// Наименование модуля системы
        /// </summary>
        [Display(Name="Наименование модуля системы")]
        public string SystemModuleName { get; set; }

        /// <summary>
        /// Список сопоставлений модулей системы и организаций
        /// </summary>
        public List<OrganizationToSystemModule> OrganizationToSystemModules { get; set; }
    }
}