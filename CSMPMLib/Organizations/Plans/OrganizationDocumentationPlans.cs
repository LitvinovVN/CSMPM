using System.Collections.Generic;

namespace CSMPMLib
{
    /// <summary>
    /// Документация организации. Планы.
    /// </summary>
    public class OrganizationDocumentationPlans
    {
        public int OrganizationDocumentationPlansId { get; set; }
        public string OrganizationDocumentationPlansName { get; set; }

        public int OrganizationDocumentationId { get; set; }
        public OrganizationDocumentationItem OrganizationDocumentation { get; set; }

        /// <summary>
        /// Планы поливов
        /// </summary>
        public List<IrrigationPlan> IrrigationPlans { get; set; }
    }
}