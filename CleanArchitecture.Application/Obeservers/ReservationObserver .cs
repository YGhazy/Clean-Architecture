using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Domain.IRepository;

namespace CleanArchitecture.Application.Obeservers
{
    public class ReservationObserver : ICustomObserver<Reservation>
    {
        private readonly IScreenShowRepository _screenShowRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReservationObserver(IUnitOfWork unitOfWork, IScreenShowRepository screenShowRepository)
        {
            _screenShowRepository = screenShowRepository;
            _unitOfWork = unitOfWork;

        }

        public async Task Update(Reservation reservation)
        {
            var screenShow = await _screenShowRepository.GetByIdAsync(reservation.ScreenShowId);

            // Update the available seats 
            if (reservation.ReservationState == ReservationStateEnum.Confirmed)
            {
                screenShow.AvailableSeats -= reservation.NumberOfSeats;
            }
            else if (reservation.ReservationState == ReservationStateEnum.CanceledByCustomer || reservation.ReservationState == ReservationStateEnum.CanceledByCinema)
            {
                screenShow.AvailableSeats += reservation.NumberOfSeats;
            }

            await _screenShowRepository.UpdateAsync(screenShow);
            await _unitOfWork.SaveChangesAsync();
        }

    }

}