namespace ClassroomService.Data.Interfaces
{
    public interface ICRUDRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> GetById(Guid id);
        void Update(T entity);
        void Delete(T entity);
    }
}
