using AutoMapper;
using UniversityBuildingService.Dtos;
using UniversityBuildingService.Models;

namespace UniversityBuildingService.Profiles
{
    public class UniversityBuildingProfile: Profile
    {
        public UniversityBuildingProfile()
        {
            CreateMap<UniversityBuilding, BuildingReadDto>();
            CreateMap<BuildingCreateDto, UniversityBuilding>();                
            CreateMap<BuildingUpdateDto, UniversityBuilding>();
        }
    }
}
