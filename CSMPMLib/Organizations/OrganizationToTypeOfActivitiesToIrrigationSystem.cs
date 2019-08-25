using System.ComponentModel.DataAnnotations;

namespace CSMPMLib
{
    /// <summary>
    /// Модель, отражающая взаимосвязь организации
    /// с системами орошения (сопоставление  
    /// система - сопоставление организация - вид деятельности (эксплуатация, использование))
    /// </summary>
    public class OrganizationToTypeOfActivitiesToIrrigationSystem
    {
        public int Id { get; set; }               

        [Display(Name = "Оросительная система")]
        public int IrrigationSystemId { get; set; }
        public IrrigationSystem IrrigationSystem { get; set; }

        [Display(Name = "Организация - тип деятельности")]
        public int OrganizationToTypeOfActivityId { get; set; }
        public OrganizationToTypeOfActivity OrganizationToTypeOfActivity { get; set; }
    }
}