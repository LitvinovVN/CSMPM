using System.ComponentModel.DataAnnotations;

namespace CSMPMWeb.Models
{
    /// <summary>
    /// Разрешение на использование модуля системы
    /// </summary>
    public class AssignedPermission
    {
        /// <summary>
        /// УИД
        /// </summary>
        public int AssignedPermissionId { get; set; }

        /// <summary>
        /// УИД привязки пользователя к организации
        /// </summary>
        public int AppUserToOrganizationId { get; set; }
        /// <summary>
        /// Привязка пользователя к организации
        /// </summary>
        public AppUserToOrganization AppUserToOrganization { get; set; }
        
        /// <summary>
        /// УИД модуля системы, доступного организации
        /// </summary>
        public int OrganizationToSystemModuleId { get; set; }
        public OrganizationToSystemModule OrganizationToSystemModule { get; set; }

        /// <summary>
        /// УИД роли 
        /// </summary>
        public int SystemRoleId { get; set; }
        public SystemRole SystemRole { get; set; }
}
}