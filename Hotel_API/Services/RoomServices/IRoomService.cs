using Hotel_API.Dtos.Reservation;
using Hotel_API.Dtos.Room;
using Hotel_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Hotel_API.Services.ReservationServices
{
    public interface IRoomService
    {
        public Task<ServiceResponse<List<GetRoomDto>>> AddRoom(AddRoomDto c);
        public Task<ServiceResponse<List<GetRoomDto>>> GetAllRooms();
        public Task<ServiceResponse<GetRoomDto>> GetRoomById(int id);
        public Task<ServiceResponse<GetRoomDto>> UpdateRoom(UpdateRoomDto x);
        public Task<ServiceResponse<List<GetRoomDto>>> RemoveRoom(int id);
        public Task<ServiceResponse<GetRoomDto>> AddReservationOnRoom(int roomId, AddReservationDto l);
        public Task<ServiceResponse<List<GetReservationDto>>> GetReservationsOnRoom(int roomId);
        public Task<ServiceResponse<List<GetRoomDto>>> GetMyRooms();
    }
}
