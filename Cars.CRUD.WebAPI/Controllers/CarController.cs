using Cars.CRUD.WebAPI.Data;
using Cars.CRUD.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars.CRUD.WebAPI.Controllers
{
    [ApiController]
    [Route("api/Cars")]
    public class CarController : ControllerBase
    {
        private readonly CarsContext _context;

        public CarController(CarsContext context)
        {
            _context = context;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            return await _context.Cars.ToListAsync();
        }

        // GET: api/Cars/3
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>>GetCar(int id)
        {
            var car=await _context.Cars.SingleOrDefaultAsync(car=>car.Id==id);

            if (car==null)
            {
                return NotFound();
            }

            return new ObjectResult(car);
        }

        // PUT: api/Cars
        [HttpPut]
        public async Task<ActionResult<Car>>PutCar(Car carCorrection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_context.Cars.Any(car => car.Id==carCorrection.Id))
            {
                return NotFound();
            }

            _context.Update(carCorrection);
            await _context.SaveChangesAsync();
            return Ok(carCorrection);
        }

        // POST: api/Cars
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car newCar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cars.Add(newCar);
            await _context.SaveChangesAsync();
            return Ok(newCar);
        }

        // DELETE: api/Cars/3
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> DeleteCar(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var car =await _context.Cars.SingleOrDefaultAsync(car => car.Id==id);

            if (car==null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return Ok(car);
        }
    }
}
