using AutoMapper;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Application.Services.IServices;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.IRepository;
using CleanArchitecture.Infrastructure.Mappers;
using CleanArchitecture.Infrastructure.Persistence.Data_context;
using CleanArchitecture.Infrastructure.Persistence.Repositories;
using CleanArchitecture.Infrastructure.Persistence.Unit_of_work;
using CleanArchitecture.Infrastructure.Services;
using CleanArchitecture.WebAPI.Controllers;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Setup
{
    public static class SetupApplicationServices
    {
        public  static void SetupServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Context
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging(true);
            });
            #endregion

            #region Repos
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IReservationSeatRepository, ReservationSeatRepository>();
            services.AddScoped<ISeatRepository, SeatRepository>();
            services.AddScoped<IScreenShowRepository, ScreenShowRepository>();
            services.AddScoped<IScreenRepository, ScreenRepository>();
            services.AddScoped<IShowRepository, ShowRepository>();
            services.AddScoped<ITheaterRepository, TheaterRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion


            #region Mapper

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            #endregion

            #region Identity
            //services.AddScoped<ApplicationUserManager>();
            #endregion

            #region payment
            services.AddScoped<IPaymentFactory, PaymentFactory>();
            //to resolve it in runtime
            services.AddScoped<CreditCardPayment>()
            .AddScoped<IPayment, CreditCardPayment>(s => s.GetService<CreditCardPayment>());
            services.AddScoped<PayPalPayment>()
            .AddScoped<IPayment, PayPalPayment>(s => s.GetService<PayPalPayment>());
            services.AddScoped<BitcoinPayment>()
            .AddScoped<IPayment, BitcoinPayment>(s => s.GetService<BitcoinPayment>());

            #endregion
            #region reservation
            services.AddScoped< ReservationService>();
            services.AddScoped<IReservationService>(provider => new ReservationProxyService(provider.GetService<ReservationService>())); //, provider.GetService<ILogger<ReservationProxyService>>()

            #endregion


        }
    }
}