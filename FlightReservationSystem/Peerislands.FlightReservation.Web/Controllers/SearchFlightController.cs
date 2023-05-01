using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerislands.FlightReservation.Contract.Interfaces;
using Peerislands.FlightReservation.DataContract.Messages;

namespace Peerislands.FlightReservation.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchFlightController : ControllerBase
    {
        private readonly ISearchFlightInteractor _searchFlightInteractor;
        public SearchFlightController(ISearchFlightInteractor searchFlightInteractor)
        {
            this._searchFlightInteractor = searchFlightInteractor;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SearchFlightResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("search")]
        public async Task<SearchFlightResponse> SearchFlightAsync(SearchFlightRequest searchFlightRequest)
        {
            return await _searchFlightInteractor.SearchFlightAsync(searchFlightRequest);
        }
    }
}
