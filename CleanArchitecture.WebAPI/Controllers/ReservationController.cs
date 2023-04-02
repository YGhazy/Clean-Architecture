using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Application.Services.IServices;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.IRepository;
using Microsoft.AspNetCore.Mvc;
using Stack.API.Controllers.Common;

namespace CleanArchitecture.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ReservationController : BaseResultHandlerController<IReservationService>
    {
        //private readonly ILogger<WeatherForecastController> _logger;
        private readonly ILogging _logging;
        private readonly IPaymentFactory _paymentFactory;
        private readonly ISeatRepository _reservationRepository;

        public ReservationController(IPaymentFactory paymentFactory, IReservationService reservationService, ISeatRepository reservationRepository ) : base(reservationService)
        {
            _logging = FileLogging.Instance;
            _paymentFactory = paymentFactory;
            _reservationRepository = reservationRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationRequest request)
        {

            return await AddItemResponseHandler(async () => await service.CreateReservationAsync(request));
        }

        [HttpPost]
        [Route("{request}")]
        public async Task<IActionResult> CancelReservationByCustomer(int request)
        {

            return await EditItemResponseHandler(async () => await service.CancelReservationByCustomerAsync(request));
        }

        [HttpPost]
        [Route("{request}")]

        public async Task<IActionResult> CancelReservationByCinema(int request)
        {

            return await EditItemResponseHandler(async () => await service.CancelReservationByCinemaAsync(request));
        }
        [HttpPost]
        [Route("{request}")]

        public async Task<IActionResult> ConfirmReservationAsync(int request)
        {

            return await EditItemResponseHandler(async () => await service.ConfirmReservationAsync(request));
        }
    }
}


