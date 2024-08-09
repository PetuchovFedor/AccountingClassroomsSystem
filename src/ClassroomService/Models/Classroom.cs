namespace ClassroomService.Models
{
    public class Classroom
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Capacity { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public Guid ClassroomTypeId { get; set; }
        public ClassroomType? ClassroomType { get; set; }
        public Guid UniversityBuildingId { get; set; }
        public UniversityBuilding? UniversityBuilding { get; set; }
    }
}
