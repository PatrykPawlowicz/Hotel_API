using AutoMapper;
using Hotel_API.Data;
using Hotel_API.Dtos.Reservation;
using Hotel_API.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hotel_API.Services.ReservationServices
{
    public class ReservationService : IReservationService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _contextAccessor;
        public ReservationService(IMapper mapper, DataContext dataContext, IHttpContextAccessor contextAccessor)
        {
            _mapper = mapper;
            _dataContext = dataContext;
            _contextAccessor = contextAccessor;

        }
        private int GetUserId() => int.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        public async Task<ServiceResponse<GetReservationDto>> GetReservationById(int id)
        {
            var serviceResponse = new ServiceResponse<GetReservationDto>();
            var dbReservation = await _dataContext.reservations.FirstOrDefaultAsync(c => c.id == id);
            serviceResponse.data = _mapper.Map<GetReservationDto>(dbReservation);
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetReservationDto>> UpdateReservation(UpdateReservationDto l)
        {
            var serviceResponse = new ServiceResponse<GetReservationDto>();
            try
            {
                Reservation reservation = await _dataContext.reservations.FirstOrDefaultAsync(c => c.id == l.id && c.user.id == GetUserId());
                if (reservation != null)
                {
                    reservation.duration = l.duration;
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.data = _mapper.Map<GetReservationDto>(reservation);
                }
                else
                {
                    serviceResponse.success = false;
                    serviceResponse.messsage = "Not found!";
                }
            }
            catch (Exception e)
            {
                serviceResponse.success = false;
                serviceResponse.messsage = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetReservationDto>>> RemoveReservation(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetReservationDto>>();
            try
            {
                Reservation reservation = await _dataContext.reservations.FirstOrDefaultAsync(c => c.id == id && c.user.id == GetUserId());
                if (reservation != null)
                {
                    _dataContext.reservations.Remove(reservation);
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.data = _dataContext.reservations
                    .Select(c => _mapper.Map<GetReservationDto>(c)).ToList();
                }
                else
                {
                    serviceResponse.success = false;
                    serviceResponse.messsage = "Not found!";
                }

            }
            catch (Exception e)
            {
                serviceResponse.success = false;
                serviceResponse.messsage = e.Message;
            }
            return serviceResponse;
        }

        //public async Task<ServiceResponse<List<GetReservationDto>>> GetMyReservations(AddReservationDto c)
        //{
        //    Reservation reservation = _mapper.Map<Room>(c);
        //    reservation.user = await _dataContext.users.FirstOrDefaultAsync(u => u.id == GetUserId());
        //    _dataContext.reservations.Add(reservation);
        //    await _dataContext.SaveChangesAsync();
        //    return await GetMyReservations();
        //}
    }
}
