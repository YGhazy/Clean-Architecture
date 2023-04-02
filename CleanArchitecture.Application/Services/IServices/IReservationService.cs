using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services.IServices
{
    public interface IReservationService
    {
        Task<ApiResponse<ReservationDTO>> CreateReservationAsync(CreateReservationRequest req);
         Task<bool> UpdateReservationAsync(int reservationId, int numberOfSeats);
        public Task<ApiResponse<bool>> CancelReservationByCinemaAsync(int reservationID);
        public Task<ApiResponse<bool>> CancelReservationByCustomerAsync(int reservationID);
        public Task<ApiResponse<bool>> ConfirmReservationAsync(int reservationID);
    }
}
