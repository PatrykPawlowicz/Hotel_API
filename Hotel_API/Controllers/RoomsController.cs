using Hotel_API.Data;
using Hotel_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Hotel_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RoomsController : ControllerBase
    {
        public readonly RoomContext _context;

        public RoomsController(RoomContext context)
        {
            _context = context;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllItems()
        {
            var rooms = _context.Room.ToList();
            return Ok(rooms);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetOne(decimal id)
        {
            var room = _context.Room.Find(id);
            return Ok(room);
        }

    }
}