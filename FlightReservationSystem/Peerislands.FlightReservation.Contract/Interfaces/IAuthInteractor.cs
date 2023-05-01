using Peerislands.FlightReservation.DataContract.Models;

namespace Peerislands.FlightReservation.Contract.Interfaces
{
    public interface IAuthInteractor
    {
        string ExecuteAsync(User user);
    }
}
