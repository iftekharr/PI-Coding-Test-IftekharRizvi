using Microsoft.AspNetCore.Mvc;
using Peerislands.FlightReservation.Contract.Interfaces;
using Peerislands.FlightReservation.DataContract.Messages;

namespace Peerislands.FlightReservation.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookFlightController : ControllerBase
    {
        private readonly IBookFlightInteractor _bookFlightInteractor;
        public BookFlightController(IBookFlightInteractor bookFlightInteractor)
        {
            _bookFlightInteractor = bookFlightInteractor;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookFlightResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("book")]
        public async Task<BookFlightResponse> BookFlightAsync(BookFlightRequest bookFlightRequest)
        {
            return await _bookFlightInteractor.BookFlightAsync(bookFlightRequest);
        }
    }
}
