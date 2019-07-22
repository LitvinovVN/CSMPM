using CSMPMLib;
using System.Collections.Generic;

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

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        /// <summary>
        /// Назначенные разрешения на использование системы
        /// </summary>
        public List<AssignedPermission> AssignedPermissions { get; set; }
    }
}