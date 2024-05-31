using Hotel_API.Dtos.Reservation;
using Hotel_API.Models;
using Hotel_API.Services.ReservationServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel_API.Controllers
{

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetReservationDto>>> GetReservationById(int id)
        {
            return Ok(await _reservationService.GetReservationById(id));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetReservationDto>>> UpdateReservation(UpdateReservationDto l)
        {
            var response = await _reservationService.UpdateReservation(l);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetReservationDto>>>> RemoveReservation(int id)
        {
            var response = await _reservationService.RemoveReservation(id);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        //[HttpGet("my")]
        //public async Task<ActionResult<List<GetReservationDto>>> GetMyResercvations()
        //{
        //    return Ok(await _reservationService.GetMyReservations());
        //}
    }
}
