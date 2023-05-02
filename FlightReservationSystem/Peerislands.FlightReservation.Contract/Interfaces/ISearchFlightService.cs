using Peerislands.FlightReservation.DataContract.Messages;

namespace Peerislands.FlightReservation.Contract.Interfaces
{
    public interface ISearchFlightService
    {
        Task<SearchFlightResponse> SearchFlights(SearchFlightRequest searchFlightRequest);
    }
}
