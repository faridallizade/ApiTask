using ApiTask.DTOs;
using ApiTask.Entitites;

namespace ApiTask.Services.Interfaces
{
    public interface IBrandService
    {
        Task<IQueryable<Brand>> GetAll();
        Task<IQueryable<Brand>> GetById(int id);
        Task Create (BrandDto brandDto);  
    }
}
