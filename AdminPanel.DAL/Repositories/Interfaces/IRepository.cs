using System.Linq.Expressions;

namespace AdminPanel.DAL.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        public Task<T> AddAsync(T entity);
        public T Update(T entity);
        public Task<bool> DeleteAsync(Guid deleteId);
        public Task<IEnumerable<T>> GetAllWhereAsync(Expression<Func<T, bool>> expression);
        public Task<T?> GetOneWhereAsync(Expression<Func<T, bool>> expression);
        public Task<bool> SaveAsync();
    }
}
