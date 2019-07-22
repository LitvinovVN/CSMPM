using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSMPMWeb.Models
{
    /// <summary>
    /// Модель пользователя приложения
    /// </summary>
    public class AppUser : IdentityUser
    {
        /// <summary>
        /// Имя
        /// </summary>
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        /// <summary>
        /// ФИО полностью
        /// </summary>
        [Display(Name = "ФИО")]
        public string GetFullName
        {
            get
            {
                return LastName + " " + FirstName + " " + Patronymic;
            }
        }

        /// <summary>
        /// Р
        /// </summary>
        public List<AppUserToOrganization> AppUserToOrganizationWithAppUserPermissions { get; set; }
    }
}