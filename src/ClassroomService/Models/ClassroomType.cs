namespace ClassroomService.Models
{
    public class ClassroomType
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Classroom> Classrooms { get; set; } = [];
    }
}
