using AutoMapper;
using CleanArchitecture.Application.Commands.Reservations;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Services.IServices;
using CleanArchitecture.Application.Services.MailerService;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Domain.IRepository;
using CleanArchitecture.Infrastructure.Services.MailerService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.NetworkInformation;

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
        private readonly IMailServiceFactory _mailServiceFactory;
        private readonly IMailWrapDecoratorFactory _mailDecoratorFactory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomObservable<Reservation> _reservationObservable;
        private readonly ICustomObserver<Reservation> _reservationObserver;
        private readonly ReservationManager _reservationManager;
        public ReservationService(IMapper mapper, IUnitOfWork unitOfWork,IMovieRepository movieRepository, IUserRepository userRepository, IScreenShowRepository screenShowRepository, IReservationRepository reservationRepository, IPaymentFactory paymentFactory, ICustomObservable<Reservation> reservationObservable, ICustomObserver<Reservation> reservationObserver, IMailWrapDecoratorFactory MailWrapDecoratorFactory, IMailServiceFactory mailServiceFactory, ReservationManager reservationManager)
        {
            _movieRepository = movieRepository;
            _reservationRepository = reservationRepository;
            _userRepository = userRepository;
            _screenShowRepository = screenShowRepository;
            _paymentFactory = paymentFactory;
            _mailDecoratorFactory = MailWrapDecoratorFactory;
            _mailServiceFactory = mailServiceFactory;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _reservationObservable = reservationObservable;
            _reservationObservable.AddObserver(reservationObserver);
            _mailServiceFactory = mailServiceFactory;
            _reservationManager = reservationManager;
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

                _reservationManager.Invoke(
                    new CreateReservationCommand(_reservationRepository, _unitOfWork, reservation));

                // Create the payment for the reservation
                var payment = _paymentFactory.CreatePayment(reservation.PaymentMethod);

                //Process the payment
                //PayPalPayment return false otherwise true, PaymentMethod=1 
                 var paymentResult =payment.ProcessPayment(reservation.Price);

                if (!paymentResult)
                {
                    _reservationManager.Undo();
                }

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

            // Update the reservation with the new number of seats
            reservation.NumberOfSeats = numberOfSeats;
            await _reservationRepository.UpdateAsync(reservation);

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


                //  mail services
                var cloudMailService = new CloudMailService();
                cloudMailService.SendMail("Hi there.");

                var onPremiseMailService = new OnPremiseMailService();
                onPremiseMailService.SendMail("Hi there.");

                // add behavior
                var statisticsDecorator = new StatisticsDecorator(cloudMailService);
                statisticsDecorator.SendMail($"Hi there via {nameof(StatisticsDecorator)} wrapper.");

                // add behavior
                var messageDatabaseDecorator = new MessageDatabaseDecorator(cloudMailService);
                messageDatabaseDecorator.SendMail(
                    $"Hi there via {nameof(MessageDatabaseDecorator)} wrapper, message 1.");
                messageDatabaseDecorator.SendMail(
                    $"Hi there via {nameof(MessageDatabaseDecorator)} wrapper, message 2.");

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


                //// first way to call mail service and wrap it with decorator
                //  mail services
                var cloudMailService = new CloudMailService();
                cloudMailService.SendMail("Hi there.");

                var onPremiseMailService = new OnPremiseMailService();
                onPremiseMailService.SendMail("Hi there.");

                // add behavior
                var statisticsDecorator = new StatisticsDecorator(cloudMailService);
                statisticsDecorator.SendMail($"Hi there via {nameof(StatisticsDecorator)} wrapper.");

                // add behavior
                var messageDatabaseDecorator = new MessageDatabaseDecorator(cloudMailService);
                messageDatabaseDecorator.SendMail(
                    $"Hi there via {nameof(MessageDatabaseDecorator)} wrapper, message 1.");
                messageDatabaseDecorator.SendMail(
                    $"Hi there via {nameof(MessageDatabaseDecorator)} wrapper, message 2.");

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

                //state pattern
                reservation.Confirm();

                // update the reservation
                await _reservationRepository.UpdateAsync(reservation);
                await _unitOfWork.SaveChangesAsync();

                // Notify the observers
                await _reservationObservable.NotifyObservers(reservation);

                //// second way to call mail service and wrap it with decorator
                var msg = $"Reservation with ID:{reservationID} has been confirmed successfully";
                // Create the mail services
                var cloudMailService = _mailServiceFactory.CreateMailService(MailMethod.Cloud);
                var onPremiseMailService = _mailServiceFactory.CreateMailService(MailMethod.OnPremise);
                cloudMailService.SendMail(msg);
                onPremiseMailService.SendMail(msg);

                // add decorator behavior to mail services
                var statisticsDecorator = _mailDecoratorFactory.CreateDecoratedMailService(DecoratorMethod.StatisticsDecorator, cloudMailService);
                statisticsDecorator.SendMail(msg);

                var messageDatabaseDecorator = _mailDecoratorFactory.CreateDecoratedMailService(DecoratorMethod.MessageDatabase, onPremiseMailService);
                messageDatabaseDecorator.SendMail(msg);


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
