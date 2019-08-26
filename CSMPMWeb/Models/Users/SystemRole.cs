
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSMPMWeb.Models
{
    /// <summary>
    /// Роль пользователя при использовании модулей системы
    /// </summary>
    public class SystemRole
    {
        /// <summary>
        /// УИД
        /// </summary>
        [Display(Name = "Роль пользователя при использовании модулей системы")]
        public int SystemRoleId { get; set; }

        [Display(Name = "Наименование роли пользователя при использовании модулей системы")]
        public string SystemRoleName { get; set; }

        /// <summary>
        /// Назначенные разрешения на использование модулей системы
        /// </summary>
        public List<AssignedPermission> AssignedPermissions { get; set; }
    }
}