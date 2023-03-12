using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Services.IServices;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class ReservationProxyService : IReservationService
    {
        private readonly IReservationService _realService;

        public ReservationProxyService(IReservationService realService)
        {
            _realService = realService;
        }
        public Task<ApiResponse<ReservationDTO>> CreateReservationAsync(CreateReservationRequest req)
        {
            if (!IsUserValid(req.UserId))
            {
                throw new ArgumentException("User not found.");
            }
            if (!IsSeatsAvailable(req.Seats.Length))
            {
                throw new ArgumentException("Not enough available seats.");
            }
            // Forward the request to the real service
            var result = _realService.CreateReservationAsync(req);
            return result;
        }

        public Task<bool> CancelReservationAsync(int reservationId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateReservationAsync(int reservationId, int numberOfSeats)
        {
            throw new NotImplementedException();
        }


        //Proxy validation methods
        private bool IsUserValid(int UserId)
        {
            return true;
        }

        private bool IsSeatsAvailable(int number)
        {
            return true;
        }
    }
}
