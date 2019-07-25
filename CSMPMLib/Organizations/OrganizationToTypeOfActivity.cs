namespace CSMPMLib
{
    /// <summary>
    /// Сопоставление организации и вида деятельности
    /// </summary>
    public class OrganizationToTypeOfActivity
    {
        public int OrganizationToTypeOfActivityId { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public int TypeOfActivityId { get; set; }
        public TypeOfActivity TypeOfActivity { get; set; }
}
}