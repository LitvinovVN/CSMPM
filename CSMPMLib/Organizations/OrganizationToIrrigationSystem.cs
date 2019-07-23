namespace CSMPMLib
{
    /// <summary>
    /// Модель, отражающая взаимосвязь организации
    /// с системами орошения (сопоставление организация - 
    /// система - тип связи (эксплуатация, использование))
    /// </summary>
    public class OrganizationToIrrigationSystem
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public int IrrigationSystemId { get; set; }
        public IrrigationSystem IrrigationSystem { get; set; }
        
        public int OrganizationToSystemRelationTypeId { get; set; }
        public OrganizationToSystemRelationType OrganizationToSystemRelationType { get; set; }
    }
}