using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Services.IServices;
using CleanArchitecture.Domain.IRepository;

namespace CleanArchitecture.Application.Services
{
    public class ReservationProxyService : IReservationService
    {
        private readonly IReservationService _realService;
        private readonly IReservationRepository _reservationRepository;
        private readonly IScreenShowRepository _screenShowRepository;

        public ReservationProxyService(IReservationService realService, IScreenShowRepository screenShowRepository, IReservationRepository reservationRepository)
        {
            _realService = realService;
            _reservationRepository = reservationRepository;
            _screenShowRepository = screenShowRepository;

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

        public async Task<ApiResponse<bool>> CancelReservationByCinemaAsync(int reservationID)

        {
            ApiResponse<bool> result = new ApiResponse<bool>();
            try
            {
                var reservation = await _reservationRepository.GetByIdAsync(reservationID);
                if (reservation == null)
                {
                    result.Succeeded = false;
                    result.Data = false;
                    return result;
                }
                return await _realService.CancelReservationByCinemaAsync(reservationID);
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                result.Errors.Add(ex.Message);
                result.ErrorType = ErrorType.SystemError;
                return result;
            }
        }
        public async Task<ApiResponse<bool>> CancelReservationByCustomerAsync(int reservationID)

        {
            ApiResponse<bool> result = new ApiResponse<bool>();
            try
            {
                var reservation = await _reservationRepository.GetByIdAsync(reservationID);
                if (reservation == null)
                {
                    result.Succeeded = false;
                    result.Data = false;
                    return result;
                }
                return await _realService.CancelReservationByCustomerAsync(reservationID);
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                result.Errors.Add(ex.Message);
                result.ErrorType = ErrorType.SystemError;
                return result;
            }
        }
        public async Task<ApiResponse<bool>> ConfirmReservationAsync(int reservationID)

        {
            ApiResponse<bool> result = new ApiResponse<bool>();
            try
            {
                var reservation = await _reservationRepository.GetByIdAsync(reservationID);
                if (reservation == null)
                {
                    result.Succeeded = false;
                    result.Data = false;
                    return result;
                }
                return await _realService.ConfirmReservationAsync(reservationID);
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                result.Errors.Add(ex.Message);
                result.ErrorType = ErrorType.SystemError;
                return result;
            }
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
