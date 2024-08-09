namespace UniversityBuildingService.Dtos
{
    public class BuildingReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int FloorsCount { get; set; }
    }
}
