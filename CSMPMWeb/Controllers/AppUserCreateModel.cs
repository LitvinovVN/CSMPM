using System.ComponentModel.DataAnnotations;

namespace CSMPMWeb.Controllers
{
    /// <summary>
    /// Модель представления для регистрации нового пользователя
    /// </summary>
    public class AppUserCreateModel
    {
        /// <summary>
        /// Имя
        /// </summary>
        [Display(Name = "Имя")]
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Display(Name = "Фамилия")]
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Required]
        /// <summary>
        /// Имя в системе
        /// </summary>
        [Display(Name = "Имя в системе")]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        /// <summary>
        /// Пароль
        /// </summary>
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}