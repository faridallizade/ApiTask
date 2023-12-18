using ApiTask.DAL;
using ApiTask.Entitites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Drawing;

namespace ApiTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ColorController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("{id}")] 
        public async Task<IActionResult> Get()
        {
            List<Colour> colors = await _context.Color.ToListAsync();
            return StatusCode(StatusCodes.Status200OK,colors);
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var color = await _context.Color.FirstOrDefaultAsync(c=>c.Id == id);
            if (color == null) return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(StatusCodes.Status200OK,color);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Colour color)
        {
            await _context.Color.AddAsync(color);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id,string name)
        {
            if(id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            var color = await _context.Color.FirstOrDefaultAsync(c=>c.Id == id);
            if (color == null) return StatusCode(StatusCodes.Status404NotFound);
            color.Name = name;
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK,color);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if(id<=0)
                return BadRequest("Invalid id value");

            var existingColor = _context.Color.Find(id);
            if(existingColor == null)
                return NotFound();

            _context.Color.Remove(existingColor);
            _context.SaveChanges();
            return Ok();
        }

    }
}
