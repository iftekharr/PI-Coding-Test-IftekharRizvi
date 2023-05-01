using Peerislands.FlightReservation.Contract.Interfaces;
using Peerislands.FlightReservation.DataContract.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peerislands.FlightReservation.Interactor
{
    public class SearchFlightInteractor : ISearchFlightInteractor
    {
        private readonly ISearchFlightService _searchFlightService;

        public SearchFlightInteractor(ISearchFlightService searchFlightService)
        {
            this._searchFlightService = searchFlightService;
        }
        public async Task<SearchFlightResponse> SearchFlightAsync(SearchFlightRequest searchFlightRequest)
        {
            if (searchFlightRequest == null)
                throw new ArgumentNullException(nameof(searchFlightRequest));
            return await _searchFlightService.SearchFlights(searchFlightRequest);
        }
    }
}
