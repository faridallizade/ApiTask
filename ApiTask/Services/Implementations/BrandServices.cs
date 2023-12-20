using ApiTask.DTOs;
using ApiTask.Entitites;
using ApiTask.Repositories.Interfaces;
using ApiTask.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiTask.Services.Implementations
{
    public class BrandServices : IBrandService
    {
        private readonly IBrandRepo _repository;
        public BrandServices(IBrandRepo repository)
        {
            _repository = repository;
        }

        public async Task Create(BrandDto brandDto)
        {
            if (brandDto == null) throw new Exception("Not null");
            Brand brand = new Brand()
            {
                Name = brandDto.Name,
            };
           await _repository.Create(brand);
            await _repository.SaveChangesAsync();
        }

        public async Task<IQueryable<Brand>> GetAll()
        {
            return await _repository.GetAllAsync(orderByExpression: c=>c.Name,isDescending : false);
        }

        public async Task<Brand> GetById(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            var brand = await _repository.GetByIdAsync(id);
            if (brand == null) throw new Exception("Not found");
            return brand;
        }

        
    }
}
