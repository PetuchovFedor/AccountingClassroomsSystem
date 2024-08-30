using ClassroomService.Data.Interfaces;
using ClassroomService.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassroomService.Data.Implementations
{
    public class ClassroomRepository : CRUDRepository<Classroom>, ICRUDRepository<Classroom>
    {
        public ClassroomRepository(AppDbContext context)
            : base(context)
        {

        }
        public override async Task<IEnumerable<Classroom>> GetAll()
        {
            var result = await _context.Classrooms
                .Include(x => x.ClassroomHasAdditionalFields)
                .ThenInclude(y => y.AdditionalField)
                .Include(x => x.UniversityBuilding)
                .Include(x => x.ClassroomType)
                .ToListAsync();
            return result;
        }
        public override Task<Classroom> GetById(Guid id)
        {
            var entity = _context.Classrooms
                .Include(x => x.ClassroomHasAdditionalFields)
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }        
    }
}
