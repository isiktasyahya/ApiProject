using ApiProjectKampi.WebApi.Context;
using ApiProjectKampi.WebApi.Dtos.ImageDtos;
using ApiProjectKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagessController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public ImagessController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> ImageList()
        {
            var values = _context.Images.ToList();
            return Ok(values);
        }
        [HttpDelete]
        public IActionResult DeleteImage(int id)
        {
            var values = _context.Images.Find(id);
            _context.Images.Remove(values);
            _context.SaveChanges();
            return Ok("Silme İşlemi Başarılı");
        }
        [HttpPost]
        public IActionResult CreateImage(CreateImageDto createImageDto)
        {
            var values = _mapper.Map<Image>(createImageDto);
            _context.Images.Add(values);
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı");
        }
        [HttpGet("GetImage")]
        public IActionResult GetImage(int id)
        {
            var value = _context.Images.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateImage(UpdateImageDto updateImageDto)
        {
            var values = _mapper.Map<Image>(updateImageDto);
            _context.Images.Update(values);
            _context.SaveChanges();
            return Ok("Güncelleme İşlemi Başarılı");
        }
    }
}
