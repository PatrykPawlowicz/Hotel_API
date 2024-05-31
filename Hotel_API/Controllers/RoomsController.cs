using Hotel_API.Dtos.Reservation;
using Hotel_API.Dtos.Room;
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
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetRoomDto>>> GetRoomById(int id)
        {
            return Ok(await _roomService.GetRoomById(id));
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetRoomDto>>>> GetAllRooms()
        {

            return Ok(await _roomService.GetAllRooms());
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetRoomDto>>>> AddReservation(AddRoomDto c)
        {
            return Ok(await _roomService.AddRoom(c));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetRoomDto>>> UpdateReservation(UpdateRoomDto x)
        {
            var response = await _roomService.UpdateRoom(x);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetRoomDto>>>> RemoveRoom(int id)
        {
            var response = await _roomService.RemoveRoom(id);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPost("{id}")]
        public async Task<ActionResult<ServiceResponse<GetRoomDto>>> AddReservationOnRoom(int id, AddReservationDto l)
        {
            return Ok(await _roomService.AddReservationOnRoom(id, l));
        }
        [HttpGet("{id}/reservations")]
        public async Task<ActionResult<ServiceResponse<List<GetReservationDto>>>> GetReservationsOnRoom(int id)
        {
            return Ok(await _roomService.GetReservationsOnRoom(id));
        }
    }
}
