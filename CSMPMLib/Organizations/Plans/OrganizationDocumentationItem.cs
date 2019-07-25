using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSMPMLib
{
    /// <summary>
    /// Документация организации
    /// </summary>
    public class OrganizationDocumentationItem
    {
        public int OrganizationDocumentationItemId { get; set; }

        [Display(Name = "Наименование документации")]
        public string OrganizationDocumentationItemName { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public List<OrganizationDocumentationPlans> OrganizationDocumentationPlans { get; set; }
    }
}