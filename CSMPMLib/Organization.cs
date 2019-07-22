using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSMPMLib
{
    /// <summary>
    /// Организация
    /// </summary>
    public class Organization
    {
        /// <summary>
        /// УИД организации
        /// </summary>
        public int OrganizationId { get; set; }

        /// <summary>
        /// Наименование организации
        /// </summary>
        [Display(Name = "Наименование организации")]
        public string OrganizationName { get; set; }

        /// <summary>
        /// УИД головной организации
        /// </summary>
        public int? ParentOrganizationId { get; set; }
        
        /// <summary>
        /// Оросительные системы, находящиеся в ведении организации
        /// </summary>
        public List<IrrigationSystem> IrrigationSystems { get; set; }

        /// <summary>
        /// Пользователи системы с назначенными разрешениями на использование отдельных модулей системы
        /// </summary>
        //public List<AppUserToOrganization> AppUserToOrganizations { get; set; }
    }
}