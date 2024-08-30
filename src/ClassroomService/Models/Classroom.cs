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
        public ICollection<AdditionalField> AdditionalFields { get; set; } = [];
        public ICollection<ClassroomHasAdditionalField> ClassroomHasAdditionalFields { get; set; } = [];

        public void Update(string name, int capacity, int number, int floor, 
            Guid classroomTypeId, Guid universityBuildingId)
        {
            Name = name;
            Capacity = capacity;
            Number = number;
            Floor = floor;
            ClassroomTypeId = classroomTypeId;
            UniversityBuildingId = universityBuildingId;
        }
    }
}
