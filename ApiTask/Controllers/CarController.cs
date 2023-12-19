using ApiTask.DAL;
using ApiTask.Entitites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CarController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<Car> cars = _context.Car.ToList();
            return StatusCode(200, cars);
        }

        [HttpGet("{id}")]
        public ActionResult<Car> GetbyId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id value");
            }
            var car = _context.Car.Find(id);
            if (car == null)
            {

                return NotFound();
            }
            return Ok(car);
        }
        [HttpPost]
        public ActionResult Create([FromForm] Car car)
        {
            if (car == null || car.Id != 0)
            {
                return BadRequest("Invalid value");
            }
            _context.Car.Add(car);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult Update(int id, Car car)
        {
            if (id <= 0 || car == null || car.Id != id)
            {
                return BadRequest("Invalid id or car object");
            }
            var existingCar = _context.Car.Find(id);
            if (existingCar == null) return NotFound();

            existingCar.BrandId = car.BrandId;
            existingCar.ColorId = car.ColorId;
            existingCar.Modelyear = car.Modelyear;
            existingCar.DailyPrice = car.DailyPrice;
            existingCar.Description = car.Description;

            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid value");
            var existingCar = _context.Car.Find(id);
            if(existingCar == null) return NotFound();

            _context.Car.Remove(existingCar);
            _context.SaveChanges();
            return Ok();
        }
    }
}
