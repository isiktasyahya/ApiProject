using ApiProjectKampi.WebApi.Context;
using ApiProjectKampi.WebApi.Dtos.ChefDtos;
using ApiProjectKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProjectKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public ChefsController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public IActionResult ChefList()
        {
            var values = _context.Chefs.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateChef(CreateChefDto createChefDto)
        {
            var values = _mapper.Map<Chef>(createChefDto);
            _context.Chefs.Add(values);
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            var values = _context.Chefs.Find(id);
            _context.Chefs.Remove(values);
            _context.SaveChanges();
            return Ok("Silme İşlemi Başarılı");
        }
        [HttpGet("GetChef")]
        public IActionResult GetChef(int id)
        {
            var values = _context.Chefs.Find(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateChef(UpdateChefDto updateChefDto)
        {
            var values = _mapper.Map<Chef>(updateChefDto);
            _context.Chefs.Update(values);
            _context.SaveChanges();
            return Ok("Güncelleme İşlemi Başarılı.");
        }

    }
}
