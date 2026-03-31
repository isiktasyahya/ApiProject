using ApiProjectKampi.WebApi.Context;
using ApiProjectKampi.WebApi.Dtos.ReservationDtos;
using ApiProjectKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public ReservationsController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public IActionResult ReservationList()
        {
            var values = _context.Reservations.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateReservation(CreateReservationDto createReservationDto)
        {
            var values = _mapper.Map<Reservation>(createReservationDto);
            _context.Reservations.Add(values);
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteReservation(int id)
        {
            var values = _context.Reservations.Find(id);
            _context.Reservations.Remove(values);
            _context.SaveChanges();
            return Ok(values);
        }

        [HttpGet("GetReservation")]
        public IActionResult GetReservation(int id)
        {
            var values = _context.Reservations.Find(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateReservation(UpdateReservationDto updateReservationDto)
        {
            var values = _mapper.Map<Reservation>(updateReservationDto);
            _context.Reservations.Update(values);
            _context.SaveChanges();
            return Ok("Güncelleme İşlemi Başarılı");
        }
        [HttpGet("GetTotalReservationCount")]
        public IActionResult GetTotalReservationCount()
        {
            var values = _context.Reservations.Count();
            return Ok(values);

        }
        [HttpGet("GetTotalCustomerCount")]
        public IActionResult GetTotalCustomerCount()
        {
            var values = _context.Reservations.Sum(x => x.CountOfPeople);
            return Ok(values);
        }
        [HttpGet("GetPendingReservations")]
        public IActionResult GetPendingReservations()
        {
            var values = _context.Reservations.Where(x => x.ReservationStatus == "Onay Bekliyor").Count();
            return Ok(values);
        }
        [HttpGet("GetApprovedPendingReservations")]
        public IActionResult GetApprovedPendingReservations()
        {
            var values = _context.Reservations.Where(x => x.ReservationStatus == "Onaylandı").Count();
            return Ok(values);
        }

        [HttpGet("GetReservationStats")]
        public IActionResult GetReservationStats()
        {
            DateTime today = new DateTime(2025, 9, 17);
            DateTime fourMonthsAgo = today.AddMonths(-3);

            // 1. SQL tarafında sadece gruplama ve veri çekme
            var rawData = _context.Reservations
                .Where(r => r.ReservationDate >= fourMonthsAgo)
                .GroupBy(r => new { r.ReservationDate.Year, r.ReservationDate.Month })
                .Select(g => new
                {
                    g.Key.Year,
                    g.Key.Month,
                    Approved = g.Count(x => x.ReservationStatus == "Onaylandı"),
                    Pending = g.Count(x => x.ReservationStatus == "Onay Bekliyor"),
                    Canceled = g.Count(x => x.ReservationStatus == "İptal Edildi")
                })
                .OrderBy(x => x.Year).ThenBy(x => x.Month)
                .ToList(); // Burada SQL biter, veriler RAM’e alınır

            // 2. Bellekte DTO'ya mapleme + tarih formatlama
            var result = rawData.Select(x => new ReservationChartDto
            {
                Month = new DateTime(x.Year, x.Month, 1).ToString("MMM yyyy"),
                Approved = x.Approved,
                Pending = x.Pending,
                Canceled = x.Canceled
            }).ToList();

            return Ok(result);
        }

    }
}
