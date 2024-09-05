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

        //// GET: api/Cars/3
        //[HttpGet]



    }
}
