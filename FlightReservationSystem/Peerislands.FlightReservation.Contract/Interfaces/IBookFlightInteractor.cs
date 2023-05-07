using Peerislands.FlightReservation.DataContract.Messages;

namespace Peerislands.FlightReservation.Contract.Interfaces
{
    public interface IBookFlightInteractor
    {
        Task<BookFlightResponse> BookFlightAsync(BookFlightRequest bookFlightRequest);
    }
}
