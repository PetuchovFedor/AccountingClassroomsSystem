using Microsoft.EntityFrameworkCore;
using UniversityBuildingService.Models;

namespace UniversityBuildingService.Data
{
    public class UniversityBuildingRepository : IUniversityBuildingRepository
    {
        private readonly AppDbContext _context;
        public UniversityBuildingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UniversityBuilding> Add(UniversityBuilding entity)
        {
            var entry = await _context.Buildings.AddAsync(entity);           
            return entry.Entity;            
        }

        public void Delete(UniversityBuilding entity)
        {
            _context.Buildings.Remove(entity);                   
        }

        public async Task<UniversityBuilding> GetById(Guid id)
        {
            var entity = await _context.Buildings.SingleOrDefaultAsync(x => x.Id == id);
            return entity;            
        }

        public async Task<UniversityBuilding> GetByName(string name)
        {
            var entity = await _context.Buildings.SingleOrDefaultAsync(x => x.Name == name);
            return entity;
        }

        public async Task SaveShanges()
        {
            await _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }

        public void Update(UniversityBuilding entity)
        {
            _context.Buildings.Update(entity);            
        }
    }
}
