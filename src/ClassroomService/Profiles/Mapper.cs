using AutoMapper;
using ClassroomService.Dtos;
using ClassroomService.Models;

namespace ClassroomService.Profiles
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<ClassroomCreateDto, Classroom>();
            CreateMap<ClassroomUpdateDto, Classroom>();
            CreateMap<Classroom, ClassroomReadDto>();
            CreateMap<ClassroomTypeCreateDto, ClassroomType>();
            CreateMap<ClassroomTypeUpdateDto, ClassroomType>();
            CreateMap<ClassroomType, ClassroomTypeReadDto>();
            CreateMap<BuildingCreateDto, UniversityBuilding>();
            CreateMap<BuildingUpdateDto, UniversityBuilding>();

        }
    }
}
