namespace UniversityBuildingService.Models
{
    public class UniversityBuilding
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int FloorsCount { get; set; }
    }
}
