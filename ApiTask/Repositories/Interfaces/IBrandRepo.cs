using ApiTask.Entitites;
using System.Linq.Expressions;

namespace ApiTask.Repositories.Interfaces
{
    public interface IBrandRepo
    {
        Task<IQueryable<Brand>> GetAllAsync(Expression<Func<Brand, bool>>? expression = null, params string[] includes);
        Task<Brand> GetByIdAsync(int id);
        Task Create(Brand brand);
        void Update(Brand brand);
        void Delete(Brand brand);
        Task SaveChangesAsync(); 
    }
}
