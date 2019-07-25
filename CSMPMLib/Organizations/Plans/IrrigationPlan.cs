using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSMPMLib
{
    /// <summary>
    /// План полива
    /// </summary>
    public class IrrigationPlan
    { 
        /// <summary>
        /// УИД
        /// </summary>
        public int IrrigationPlanId { get; set; }

        /// <summary>
        /// Год
        /// </summary>
        [Display(Name = "Год")]
        [Required]
        [Range(2019, 2030)]
        public int Year { get; set; }
        
        public int OrganizationDocumentationPlansId { get; set; }
        public OrganizationDocumentationPlans OrganizationDocumentationPlans { get; set; }

        /// <summary>
        /// Строки плана
        /// </summary>
        public List<IrrigationPlanItem> IrrigationPlanItems { get; set; }
    }
}