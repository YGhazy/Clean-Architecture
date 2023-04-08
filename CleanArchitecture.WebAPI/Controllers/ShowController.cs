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
    public class ShowController : BaseResultHandlerController<IShowService>
    {
        //private readonly ILogger<WeatherForecastController> _logger;
        private readonly ILogging _logging;
        private readonly IPaymentFactory _paymentFactory;
        private readonly ISeatRepository _ShowRepository;

        public ShowController(IPaymentFactory paymentFactory, IShowService ShowService, ISeatRepository ShowRepository ) : base(ShowService)
        {
            _logging = FileLogging.Instance;
            _paymentFactory = paymentFactory;
            _ShowRepository = ShowRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateShow(CreateShowModel request)
        {

            return await AddItemResponseHandler(async () => await service.CreateShowAsync(request));
        }


    }
}


