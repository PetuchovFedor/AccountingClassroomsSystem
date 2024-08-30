using ClassroomService.Data.Implementations;

namespace ClassroomService.Data.Interfaces
{
    using IUniversityBuildingRepository = ICRUDRepository<ClassroomService.Models.UniversityBuilding>;
    using IClassromTypeRepository = ICRUDRepository<ClassroomService.Models.ClassroomType>;
    using IClassroomRepository = ICRUDRepository<ClassroomService.Models.Classroom>;
    using IAdditionalFieldRepository = ICRUDRepository<ClassroomService.Models.AdditionalField>;
    public interface IUnitOfWork
    {
        IUniversityBuildingRepository BuildingRepository { get; }
        IClassromTypeRepository ClassromTypeRepository { get; }
        IClassroomRepository ClassroomRepository { get; }
        IAdditionalFieldRepository AdditionalFieldRepository { get; }
        Task SaveChanges();

    }
}
