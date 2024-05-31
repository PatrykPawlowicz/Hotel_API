using AutoMapper;
using Hotel_API.Dtos.Reservation;
using Hotel_API.Dtos.Room;
using Hotel_API.Models;

namespace Hotel_API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Reservation, GetReservationDto>();
            CreateMap<AddReservationDto, Reservation>();
            CreateMap<AddReservationDto, GetReservationDto>();
            CreateMap<Room, GetRoomDto>();
            CreateMap<AddRoomDto, Room>();
            CreateMap<AddRoomDto, GetRoomDto>();
        }
    }
}
