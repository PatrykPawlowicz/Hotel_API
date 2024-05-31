using Hotel_API.Dtos.Reservation;
using Hotel_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel_API.Services.ReservationServices
{
    public interface IReservationService
    {
        public Task<ServiceResponse<GetReservationDto>> GetReservationById(int id);
        public Task<ServiceResponse<GetReservationDto>> UpdateReservation(UpdateReservationDto l);
        public Task<ServiceResponse<List<GetReservationDto>>> RemoveReservation(int id);

        //public Task<ServiceResponse<List<GetReservationDto>>> GetMyReservations();
    }
}
