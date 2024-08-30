using ClassroomService.Data.Interfaces;
using ClassroomService.Models;

namespace ClassroomService.Data.Implementations
{
    using UniversityBuildingRepository = CRUDRepository<ClassroomService.Models.UniversityBuilding>;
    using ClassroomTypeRepository = CRUDRepository<ClassroomService.Models.ClassroomType>;
    //using ClassroomRepository = CRUDRepository<ClassroomService.Models.Classroom>;
    using AdditionalFieldRepository = CRUDRepository<ClassroomService.Models.AdditionalField>;
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private UniversityBuildingRepository _universityBuildingRepository;
        private ClassroomTypeRepository _classroomTypeRepository;
        private AdditionalFieldRepository _additionalFieldRepository;
        private ClassroomRepository _classroomRepository;
        public UnitOfWork(AppDbContext context) 
        { 
            _context = context;
        }
        public ICRUDRepository<UniversityBuilding> BuildingRepository 
        { 
            get
            {
                _universityBuildingRepository ??= new UniversityBuildingRepository(_context);
                return _universityBuildingRepository;
            }
        }

        public ICRUDRepository<ClassroomType> ClassromTypeRepository 
        { 
            get
            {
                _classroomTypeRepository ??= new ClassroomTypeRepository(_context);
                return _classroomTypeRepository;
            }
        }

        public ICRUDRepository<Classroom> ClassroomRepository 
        {
            get
            {
                _classroomRepository ??= new ClassroomRepository(_context);
                return _classroomRepository;
            }
        }

        public ICRUDRepository<AdditionalField> AdditionalFieldRepository 
        {
            get
            {
                _additionalFieldRepository ??= new AdditionalFieldRepository(_context);
                return _additionalFieldRepository;
            }
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
