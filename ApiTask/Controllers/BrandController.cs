using ApiTask.DAL;
using ApiTask.Entitites;
using ApiTask.Repositories.Interfaces;
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
        private readonly IBrandRepo _brandRepo;

        public BrandController(AppDbContext context,IBrandRepo brandRepo)
        {
            _brandRepo = brandRepo;
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var brands = await _brandRepo.GetAllAsync();
            return StatusCode(StatusCodes.Status200OK, brands);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var brand = await _brandRepo.GetByIdAsync(id);
            if (brand == null) return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(StatusCodes.Status200OK, brand);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Brand brand)
        {
            await _brandRepo.Create(brand);
            await _brandRepo.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, string name)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            var brand = await _brandRepo.GetByIdAsync(id);
            if (brand == null) return StatusCode(StatusCodes.Status404NotFound);
            brand.Name = name;
            _brandRepo.Update(brand);
            await _brandRepo.SaveChangesAsync();
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

            _brandRepo.Delete(existingBrand);
            _brandRepo.SaveChangesAsync();
            return Ok();
        }

    }
}

