using ApiTask.Entitites;
using System.Linq.Expressions;

namespace ApiTask.Repositories.Interfaces
{
    public interface IGeneric<T> where T : BaseEntity
    {
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T,bool>>? expression=null,Expression<Func<T,object>>? orderByExpression = null,
            bool isDescending = false,params string[] includes);
        Task<T> GetByIdAsync(int Id);
        Task<T> Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync();
    }
}
