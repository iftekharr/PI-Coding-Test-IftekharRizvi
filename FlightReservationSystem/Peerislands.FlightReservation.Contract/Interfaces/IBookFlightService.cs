using Peerislands.FlightReservation.DataContract.Messages;

namespace Peerislands.FlightReservation.Contract.Interfaces
{
    public interface IBookFlightService
    {
        Task<BookFlightResponse> BookFlight(BookFlightRequest bookFlightRequest);
    }
}
