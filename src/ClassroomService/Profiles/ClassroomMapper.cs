using ClassroomService.Dtos;
using ClassroomService.Models;

namespace ClassroomService.Profiles
{
    public static class ClassroomMapper
    {
        public static ClassroomReadDto Map(this Classroom classroom)
        {
            return new ClassroomReadDto
            {
                Id = classroom.Id,
                Name = classroom.Name,
                Capacity = classroom.Capacity,
                Number = classroom.Number,
                Floor = classroom.Floor,
                ClassroomType = new ClassroomTypeReadDto 
                { 
                    Id = classroom.ClassroomType.Id, 
                    Name = classroom.ClassroomType.Name,
                },
                UniversityBuilding = new BuildingReadDto
                {
                    Id = classroom.UniversityBuilding.Id,
                    Name = classroom.UniversityBuilding.Name,
                },
                AdditionalFields = new Dictionary<string, string>(
                classroom.ClassroomHasAdditionalFields.ToList()
                    .ConvertAll(item =>
                    {
                        return KeyValuePair.Create(item.AdditionalField.Name, item.Value);
                    })),
                
            };
        }       
    }
}
