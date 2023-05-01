using Microsoft.Extensions.Configuration;
using Peerislands.FlightReservation.Contract.Interfaces;
using Peerislands.FlightReservation.DataContract.Models;

namespace Peerislands.FlightReservation.Interactor
{
    public class AuthInteractor : IAuthInteractor
    {
        private readonly IAuthService _authService;
        public AuthInteractor(IAuthService authService)
        {
            _authService = authService;
        }

        public string ExecuteAsync(User user)
        {
            return _authService.Auth(user);
        }
    }
}
