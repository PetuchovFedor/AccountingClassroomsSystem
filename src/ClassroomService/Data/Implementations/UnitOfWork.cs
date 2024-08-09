using ClassroomService.Data.Interfaces;
using ClassroomService.Models;

namespace ClassroomService.Data.Implementations
{
    using UniversityBuildingRepository = CRUDRepository<ClassroomService.Models.UniversityBuilding>;
    using ClassroomTypeRepository = CRUDRepository<ClassroomService.Models.ClassroomType>;
    using ClassroomRepository = CRUDRepository<ClassroomService.Models.Classroom>;
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context) 
        { 
            _context = context;
            BuildingRepository = new UniversityBuildingRepository(context);
            ClassromTypeRepository = new ClassroomTypeRepository(context);
            ClassroomRepository = new ClassroomRepository(context);
        }
        public ICRUDRepository<UniversityBuilding> BuildingRepository { get;  }

        public ICRUDRepository<ClassroomType> ClassromTypeRepository { get; }

        public ICRUDRepository<Classroom> ClassroomRepository { get; }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
