using CSMPMLib;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSMPMWeb.Models
{
    /// <summary>
    /// Пользователи системы с назначенными разрешениями на использование отдельных модулей системы для каждой организации
    /// </summary>
    public class AppUserToOrganization
    {
        /// <summary>
        /// УИД
        /// </summary>
        public int AppUserToOrganizationId { get; set; }

        [Display(Name = "Организация")]
        public int OrganizationId { get; set; }
        [Display(Name = "Организация")]
        public Organization Organization { get; set; }

        [Display(Name = "Пользователь")]
        public string AppUserId { get; set; }
        [Display(Name = "Пользователь")]
        public AppUser AppUser { get; set; }

        /// <summary>
        /// Выбор пользователя текущей организации для работы в системе
        /// </summary>
        [Display(Name ="Текущая организация")]
        public bool IsUserSelectedAsCurrent { get; set; }

        /// <summary>
        /// Назначенные разрешения на использование системы
        /// </summary>
        public List<AssignedPermission> AssignedPermissions { get; set; }
    }
}