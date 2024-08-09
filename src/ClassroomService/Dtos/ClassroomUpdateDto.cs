namespace ClassroomService.Dtos
{
    public class ClassroomUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Capacity { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public Guid ClassroomTypeId { get; set; }
        public Guid UniversityBuildingId { get; set; }
    }
}
