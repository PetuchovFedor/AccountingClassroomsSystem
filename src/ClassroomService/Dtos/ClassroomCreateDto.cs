namespace ClassroomService.Dtos
{
    public class ClassroomCreateDto
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public Guid ClassroomTypeId { get; set; }
        public Guid UniversityBuildingId { get; set; }        
    }
}
