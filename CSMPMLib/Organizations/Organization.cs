using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSMPMLib
{
    /// <summary>
    /// Организация
    /// </summary>
    public class Organization
    {
        #region Закрытые поля
        #endregion

        #region Открытые свойства
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
        [Display(Name = "Головная организация")]
        public int? ParentOrganizationId { get; set; }

        /// <summary>
        /// Головная организация
        /// </summary>
        [Display(Name = "Головная организация")]
        public Organization ParentOrganization { get; set; }

        /// <summary>
        /// Виды деятельности организации
        /// </summary>
        public List<OrganizationToTypeOfActivity> OrganizationToTypeOfActivities { get; set; }

        /// <summary>
        /// Оросительные системы, находящиеся в ведении организации
        /// </summary>
        public List<OrganizationToIrrigationSystem> OrganizationToIrrigationSystem { get; set; }

        /// <summary>
        /// Возвращает список дочерних организаций
        /// </summary>
        public List<Organization> ChildOrganizations { get; set; } = new List<Organization>();

        /// <summary>
        /// Возвращает перечень документации организации
        /// </summary>
        public List<OrganizationDocumentationItem> OrganizationDocumentation { get; internal set; }
        #endregion

        /// <summary>
        /// Добавляет дочернюю организацию
        /// </summary>
        /// <param name="organisation"></param>
        //public void AddChildOrganization(Organization organization)
        //{
        //    ChildOrganizations.Add(organization);
        //}

        /// <summary>
        /// Пользователи системы с назначенными разрешениями на использование отдельных модулей системы
        /// </summary>
        //public List<AppUserToOrganization> AppUserToOrganizations { get; set; }
    }
}