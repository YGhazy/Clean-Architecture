using AutoMapper;
using CleanArchitecture.Application.Commands.Reservations;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Services.IServices;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Domain.IRepository;

namespace CleanArchitecture.Application.Services
{
    public class ReservationService : IReservationService 
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IUserRepository _userRepository;
        private readonly IScreenShowRepository _screenShowRepository;
        private readonly IPaymentFactory _paymentFactory;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        // private readonly ICommand _createReservationCommand;
        private readonly ICustomObservable<Reservation> _reservationObservable;
        private readonly ICustomObserver<Reservation> _reservationObserver;

        public ReservationService(IMapper mapper, IUnitOfWork unitOfWork,IMovieRepository movieRepository, IUserRepository userRepository, IScreenShowRepository screenShowRepository, IReservationRepository reservationRepository, IPaymentFactory paymentFactory, ICustomObservable<Reservation> reservationObservable, ICustomObserver<Reservation> reservationObserver)//ICommand createReservationCommand,
        {
            _movieRepository = movieRepository;
            _reservationRepository = reservationRepository;
            _userRepository = userRepository;
            _screenShowRepository = screenShowRepository;
            _paymentFactory = paymentFactory;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _reservationObservable = reservationObservable;
            _reservationObservable.AddObserver(reservationObserver);

            // _createReservationCommand = createReservationCommand;
        }

        public async Task<ApiResponse<ReservationDTO>> CreateReservationAsync(CreateReservationRequest request)
        {
            ApiResponse<ReservationDTO> result = new ApiResponse<ReservationDTO>();
            try
            {
                var user = await _userRepository.GetByIdAsync(request.UserId);
                var screenShow = await _screenShowRepository.GetByIdAsync(request.ScreenShowId);

                // Use ReservationBuilder to create a new Reservation instance
                var reservation = Reservation.Builder()
                    .WithUser(user)
                    .WithScreenShow(screenShow)
                    .WithNumberOfSeats(request.Seats.Length)
                    .WithPaymentMethod(request.PaymentMethod)
                    .Build();

                //CommandManager commandManager = new();
                //IEmployeeManagerRepository repository = new EmployeeManagerRepository();

                //commandManager.Invoke(
                //    new AddEmployeeToManagerList(repository, 1, new Employee(111, "Kevin")));
                //repository.WriteDataStore();

                //var reservationResult= await _createReservationCommand.Execute(reservation);
                // Save the reservation to the database
                //await _reservationRepository.AddAsync(reservation);

                // Create the payment for the reservation
               // var payment = _paymentFactory.CreatePayment(reservation.PaymentMethod);

                // Process the payment
//await payment.ProcessPaymentAsync(reservation.Price);

                // Update the available seats for the movie
                //movie.AvailableSeats -= request.Seats.Length;
                //await _movieRepository.UpdateAsync(movie);


                await _reservationRepository.AddAsync(reservation);
                await _unitOfWork.SaveChangesAsync();
                // Notify the observers
                await _reservationObservable.NotifyObservers(reservation);

                result.Succeeded = true;
                result.Data = _mapper.Map<ReservationDTO>(reservation);
                return result;
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                result.Errors.Add(ex.Message);
                result.ErrorType = ErrorType.SystemError;
                return result;
            }
        }

        public async Task<bool> UpdateReservationAsync(int reservationId, int numberOfSeats)
        {
            // Get the reservation with the specified ID
            var reservation = await _reservationRepository.GetByIdAsync(reservationId);
            if (reservation == null)
            {
                throw new ArgumentException("Reservation not found.");
            }

            // Check if there are enough available seats for the reservation
            //var movie = await _movieRepository.GetByIdAsync(reservation.MovieId);
            //if (movie.AvailableSeats + reservation.NumberOfSeats < numberOfSeats)
            //{
            //    throw new ArgumentException("Not enough available seats.");
            //}

            // Update the reservation with the new number of seats
            reservation.NumberOfSeats = numberOfSeats;
            await _reservationRepository.UpdateAsync(reservation);

            // Update the available seats for the movie
            //movie.AvailableSeats = movie.AvailableSeats + reservation.NumberOfSeats - numberOfSeats;
            //await _movieRepository.UpdateAsync(movie);

            return true;
        }

        public async Task<ApiResponse<bool>> CancelReservationByCinemaAsync(int reservationID)
        {
            ApiResponse<bool> result = new ApiResponse<bool>();
            try
            {
                var reservation =await _reservationRepository.GetByIdAsync(reservationID);

                reservation.CancelByCinema();
               
                // update the reservation
                await _reservationRepository.UpdateAsync(reservation);
                await _unitOfWork.SaveChangesAsync();

                // Notify the observers
                await _reservationObservable.NotifyObservers(reservation);

                result.Succeeded = true;
                result.Data = true;
                return result;
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

                reservation.CancelByCustomer();

                // update the reservation
                await _reservationRepository.UpdateAsync(reservation);
                await _unitOfWork.SaveChangesAsync();

                // Notify the observers
                await _reservationObservable.NotifyObservers(reservation);

                result.Succeeded = true;
                result.Data = true;
                return result;
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

                reservation.Confirm();

                // update the reservation
                await _reservationRepository.UpdateAsync(reservation);
                await _unitOfWork.SaveChangesAsync();

                // Notify the observers
                await _reservationObservable.NotifyObservers(reservation);

                result.Succeeded = true;
                result.Data = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                result.Errors.Add(ex.Message);
                result.ErrorType = ErrorType.SystemError;
                return result;
            }
        }
    }
}
