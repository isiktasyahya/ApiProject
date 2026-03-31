using ApiProjectKampi.WebApi.Context;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public StatisticsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            var value = _context.Products.Count();
            return Ok(value);
        }
        [HttpGet("ReservationCount")]
        public IActionResult ReservationCount()
        {
            var value = _context.Reservations.Count();
            return Ok(value);
        }
        [HttpGet("ChefCount")]
        public IActionResult ChefCount()
        {
            var value = _context.Chefs.Count();
            return Ok(value);
        }
        [HttpGet("TotalGestCount")]
        public IActionResult TotalGestCount()
        {
            var value = _context.Reservations.Sum(x => x.CountOfPeople);
            return Ok(value);
        }









    }

}
