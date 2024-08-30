namespace ClassroomService.Models
{
    public class AdditionalField
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        public ICollection<Classroom> Classrooms { get; set; } = [];
        public ICollection<ClassroomHasAdditionalField> AdditionalFieldHasClassrooms { get; set; } = [];
    }
}
