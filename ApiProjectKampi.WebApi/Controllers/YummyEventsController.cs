using ApiProjectKampi.WebApi.Context;
using ApiProjectKampi.WebApi.Dtos.YummyEventDtos;
using ApiProjectKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YummyEventsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public YummyEventsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult YummyEventList()
        {
            var values = _context.YummyEvents.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateYummyEvent(CreateYummyEventDto createYummyEventDto)
        {
            var values = _mapper.Map<YummyEvent>(createYummyEventDto);
            _context.YummyEvents.Add(values);
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteYummyEvent(int id)
        {
            var values = _context.YummyEvents.Find(id);
            _context.YummyEvents.Remove(values);
            _context.SaveChanges();
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpGet("GetYummyEvent")]
        public IActionResult GetYummyEvent(int id)
        {
            var values = _context.YummyEvents.Find(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateYummyEvent(UpdateYummyEventDto updateYummyEventDto)
        {
            var values = _mapper.Map<YummyEvent>(updateYummyEventDto);
            _context.YummyEvents.Update(values);
            _context.SaveChanges();
            return Ok("Güncelleme İşlemi Başarılı");
        }


    }
}
