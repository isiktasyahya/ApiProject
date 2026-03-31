using ApiProjectKampi.WebApi.Context;
using ApiProjectKampi.WebApi.Dtos.EmployeeTaskDtos;
using ApiProjectKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTasksController : ControllerBase
    {
        private readonly ApiContext _context;
        private IMapper _mapper;

        public EmployeeTasksController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult EmployeeTaskList()
        {
            var values = _context.EmployeeTasks.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateEmployeeTask(CreateEmployeeTaskDto createEmployeeTaskDto)
        {
            var value = _mapper.Map<EmployeeTask>(createEmployeeTaskDto);
            _context.EmployeeTasks.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteEmployeeTask(int id)
        {
            var value = _context.EmployeeTasks.Find(id);
            _context.EmployeeTasks.Remove(value);
            _context.SaveChanges();
            return Ok("Silme İşlemi Başarılı");
        }
        [HttpGet("GetEmployeeTask")]
        public IActionResult GetEmployeeTask(int id)
        {
            var value = _context.EmployeeTasks.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateEmployeeTask(UpdateEmployeeTaskDto updateEmployeeTaskDto)
        {
            var value = _mapper.Map<EmployeeTask>(updateEmployeeTaskDto);
            _context.EmployeeTasks.Update(value);
            _context.SaveChanges();
            return Ok("Güncelleme İşlemi Başarılı");
        } 
    }
}
