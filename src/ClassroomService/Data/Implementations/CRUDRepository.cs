using ClassroomService.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClassroomService.Data.Implementations
{
    public class CRUDRepository<T> : ICRUDRepository<T> where T : class
    {
        protected AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public CRUDRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public virtual async Task<T> Add(T entity)
        {
            var newEntity = await _dbSet.AddAsync(entity);
            return newEntity.Entity;
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual async Task<T> GetById(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
