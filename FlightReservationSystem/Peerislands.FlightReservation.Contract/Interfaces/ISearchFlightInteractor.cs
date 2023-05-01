using Peerislands.FlightReservation.DataContract.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peerislands.FlightReservation.Contract.Interfaces
{
    public interface ISearchFlightInteractor
    {
        Task<SearchFlightResponse> SearchFlightAsync(SearchFlightRequest searchFlightRequest);
    }
}
