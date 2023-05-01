using Peerislands.FlightReservation.DataContract.Models;

namespace Peerislands.FlightReservation.Contract.Interfaces
{
    public interface IAuthService
    {
        string Auth(User user);
    }
}
