namespace ClassroomService.Dtos
{
    public class ClassroomReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Capacity { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public ClassroomTypeReadDto ClassroomType { get; set; }
        public BuildingReadDto UniversityBuilding { get; set; } 
        public Dictionary<string, string> AdditionalFields { get; set; }
    }
}
