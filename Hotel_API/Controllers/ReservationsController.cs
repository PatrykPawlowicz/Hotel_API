using Hotel_API.Models;
using Hotel_API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;


namespace Hotel_API.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationContext _context;

        public ReservationController(ReservationContext context)
        {
            _context = context;
        }

        [HttpGet("{id_user}")]
        public IActionResult GetAll(decimal id_user)
        {
            var reservations = _context.Reservation.GroupBy(i => i.id_user==id_user);
            return Ok(reservations);
        }

        [HttpPost("{id_user}/{id_room}/{start_date}/{end_date}")]
        public IActionResult CreateNew(decimal id_user, decimal id_room,DateTime start_date,DateTime end_date)
        {
            Reservation newReservation = new Reservation();
            newReservation.id_user = id_user;
            newReservation.id_room = id_room;
            newReservation.start_date = start_date;
            newReservation.end_date = end_date;
            var reservation = _context.Reservation.Add(newReservation);
            _context.SaveChanges();
            return Ok("New reservation added!");
        }

        [HttpPut("{id_rezerwacji}/{start_date}/{end_date}")]
        public async Task<IActionResult> UpdateDates(DateTime start_date, DateTime end_date,decimal id_rezerwacji)
        {

            var newReservation = await _context.Reservation.FirstOrDefaultAsync(i => i.id_reservation == id_rezerwacji);
            if (newReservation == null)
            {
                return NotFound();
            }
            newReservation.start_date = start_date;
            newReservation.end_date = end_date;
            var reservation = _context.Reservation.Update(newReservation);
            _context.SaveChanges();
            return Ok("Reservation was updated");
        }
        [HttpDelete("{id_reservation}")]
        public ActionResult Delete(decimal id_reservation)
        {
            var reservation = _context.Reservation.FirstOrDefault(i => i.id_reservation == id_reservation);
            if (reservation == null)
            {
                return BadRequest();
            }
            _context.Reservation.Remove(reservation);
            _context.SaveChanges();
            return Ok("Reservation was removed");
        }

    }
}