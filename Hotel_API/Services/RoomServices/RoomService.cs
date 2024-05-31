using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Hotel_API.Data;
using Hotel_API.Dtos.Reservation;
using Hotel_API.Dtos.Room;
using Hotel_API.Models;
using Hotel_API.Services.ReservationServices;
using Microsoft.AspNetCore.Http;

namespace Hotel_API.Services.RoomServices
{
    public class RoomService : IRoomService
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _contextAccessor;
            public RoomService(DataContext context, IMapper mapper, IHttpContextAccessor contextAccessor)
            {
                _context = context;
                _mapper = mapper;
                _contextAccessor = contextAccessor;
            }
            public async Task<ServiceResponse<List<GetRoomDto>>> AddRoom(AddRoomDto c)
            {
                Room room = _mapper.Map<Room>(c);
                room.user = await _context.users.FirstOrDefaultAsync(u => u.id == GetUserId());
                _context.rooms.Add(room);
                await _context.SaveChangesAsync();
                return await GetMyRooms();
            }

            public async Task<ServiceResponse<GetRoomDto>> AddReservationOnRoom(int roomId, AddReservationDto l)
            {
                var response = new ServiceResponse<GetRoomDto>();
                var dbRoom = await _context.rooms.FirstOrDefaultAsync(c => c.id == roomId && c.user.id == GetUserId());
                if (dbRoom != null)
                {
                    Reservation reservation = _mapper.Map<Reservation>(l);
                    reservation.room = dbRoom;
                    reservation.user = await _context.users.FirstOrDefaultAsync(u => u.id == GetUserId());
                    _context.reservations.Add(reservation);
                    await _context.SaveChangesAsync();
                    response.data = _mapper.Map<GetRoomDto>(dbRoom);
                }
                else
                {
                    response.success = false;
                    response.messsage = "Not found!";
                }
                return response;

            }

            public async Task<ServiceResponse<List<GetRoomDto>>> GetAllRooms()
            {
                var response = new ServiceResponse<List<GetRoomDto>>();
                var dbClassrooms = await _context.rooms.ToListAsync();
                response.data = dbClassrooms.Select(c => _mapper.Map<GetRoomDto>(c)).ToList();
                return response;
            }

            public async Task<ServiceResponse<GetRoomDto>> GetRoomById(int id)
            {
                var response = new ServiceResponse<GetRoomDto>();
                var dbClassroom = await _context.rooms.FirstOrDefaultAsync(c => c.id == id);
                response.data = _mapper.Map<GetRoomDto>(dbClassroom);
                return response;
            }

            public async Task<ServiceResponse<List<GetReservationDto>>> GetReservationsOnRoom(int roomId)
            {
                var response = new ServiceResponse<List<GetReservationDto>>();
                var dbRoom = await _context.rooms.FirstOrDefaultAsync(c => c.id == roomId);
                var dbReservations = await _context.reservations.Where(c => c.room == dbRoom).ToListAsync();
                response.data = dbReservations.Select(c => _mapper.Map<GetReservationDto>(c)).ToList();
                return response;

            }

            public async Task<ServiceResponse<List<GetRoomDto>>> GetMyRooms()
            {
                var response = new ServiceResponse<List<GetRoomDto>>();
                var dbRooms = await _context.rooms.Where(c => c.user.id == GetUserId()).ToListAsync();
                response.data = dbRooms.Select(c => _mapper.Map<GetRoomDto>(c)).ToList();
                return response;
            }

            public async Task<ServiceResponse<List<GetRoomDto>>> RemoveRoom(int id)
            {
                var response = new ServiceResponse<List<GetRoomDto>>();
                try
                {
                    Room room = await _context.rooms.FirstOrDefaultAsync(c => c.id == id && c.user.id == GetUserId());
                    if (room != null)
                    {
                        _context.rooms.Remove(room);
                        await _context.SaveChangesAsync();
                        response.data = _context.rooms
                        .Where(c => c.user.id == GetUserId())
                        .Select(c => _mapper.Map<GetRoomDto>(c)).ToList();
                    }
                    else
                    {
                        response.success = false;
                        response.messsage = "Room not found!";
                    }
                }
                catch (Exception e)
                {
                    response.success = false;
                    response.messsage = e.Message;
                }
                return response;
            }

            public async Task<ServiceResponse<GetRoomDto>> UpdateRoom(UpdateRoomDto x)
            {
                var response = new ServiceResponse<GetRoomDto>();
                try
                {
                    Room room = await _context.rooms
                    .Include(c => c.user)
                    .FirstOrDefaultAsync(c => c.id == x.id && c.user.id == GetUserId());
                    if (room != null)
                    {
                        room.number = x.number;
                        room.description = x.description;
                        await _context.SaveChangesAsync();
                        response.data = _mapper.Map<GetRoomDto>(room);
                    }
                    else
                    {
                        response.success = false;
                        response.messsage = "Room not Found";
                    }
                }
                catch (Exception e)
                {
                    response.success = false;
                    response.messsage = e.Message;
                }
                return response;
            }
            private int GetUserId() => int.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

    }
}
