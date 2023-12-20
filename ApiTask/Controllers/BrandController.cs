using ApiTask.DAL;
using ApiTask.Entitites;
using ApiTask.Repositories.Implementatitons;
using ApiTask.Repositories.Interfaces;
using ApiTask.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IBrandRepo _repository;
        private readonly IBrandService _service;

        public BrandController(AppDbContext context,IBrandRepo repository, IBrandService service)
        {
            _repository = repository;
            _service = service;
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var brands = await _service.GetAll();
            return StatusCode(StatusCodes.Status200OK, brands);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var brand = await _service.GetById(id);
            return StatusCode(StatusCodes.Status200OK, brand);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Brand brand)
        {
            await _repository.Create(brand);
            await _repository.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, string name)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            var brand = await _repository.GetByIdAsync(id);
            if (brand == null) return StatusCode(StatusCodes.Status404NotFound);
            brand.Name = name;
            _repository.Update(brand);
            await _repository.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, brand);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid id value");

            var existingBrand = _context.Brand.Find(id);
            if (existingBrand == null)
                return NotFound();

            _repository.Delete(existingBrand);
            _repository.SaveChangesAsync();
            return Ok();
        }

    }
}

