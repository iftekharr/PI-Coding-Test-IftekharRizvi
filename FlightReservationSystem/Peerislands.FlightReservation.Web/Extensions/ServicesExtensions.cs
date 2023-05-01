using Peerislands.FlightReservation.Contract.Interfaces;
using Peerislands.FlightReservation.DataContract.Models;
using Peerislands.FlightReservation.Interactor;
using Peerislands.FlightReservation.Services;

namespace Peerislands.FlightReservation.Web.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddDbContext<AirportDbContext>();
            services.AddSingleton<IAuthInteractor, AuthInteractor>();
            services.AddSingleton<IAuthService, AuthService>();
            services.AddScoped<ISearchFlightInteractor, SearchFlightInteractor>();
            services.AddScoped<ISearchFlightService, SearchFlightService>();

            return services;
        }
    }
}
