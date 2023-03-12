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
    [Route("[controller]")]
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

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    _logging.LogException("error WeatherForecast");
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}


        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationRequest request)
        {
            //var payment = _paymentFactory.CreatePayment(request.PaymentMethod);
            //if (payment == null)
            //{
            //    return BadRequest("Invalid payment type.");
            //}
            //var result = await _reservationRepository.GetReservedSeatsByScreenShowIdAsync(2);
            //return Ok(result);
            return await AddItemResponseHandler(async () => await service.CreateReservationAsync(request));
        }
    }
}


