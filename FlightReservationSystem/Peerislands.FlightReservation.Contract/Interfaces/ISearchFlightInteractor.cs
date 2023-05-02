using Peerislands.FlightReservation.DataContract.Messages;

namespace Peerislands.FlightReservation.Contract.Interfaces
{
    public interface ISearchFlightInteractor
    {
        Task<SearchFlightResponse> SearchFlightAsync(SearchFlightRequest searchFlightRequest);
    }
}
