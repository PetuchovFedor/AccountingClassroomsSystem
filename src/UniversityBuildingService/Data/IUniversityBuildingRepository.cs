using UniversityBuildingService.Models;

namespace UniversityBuildingService.Data
{
    public interface IUniversityBuildingRepository
    {
        Task<UniversityBuilding> Add(UniversityBuilding entity);
        void Update(UniversityBuilding entity);
        void Delete(UniversityBuilding entity);
        Task<UniversityBuilding> GetById(Guid id);
        Task<UniversityBuilding> GetByName(string name);
        Task SaveShanges();
    }
}
