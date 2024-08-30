namespace ClassroomService.Models
{
    public class ClassroomHasAdditionalField
    {
        public string Value { get; set; }
        public Guid ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
        public Guid AdditionalFieldId { get; set; }
        public AdditionalField AdditionalField { get; set; }
    }
}
