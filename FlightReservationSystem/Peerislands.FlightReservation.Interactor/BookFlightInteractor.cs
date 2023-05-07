using Peerislands.FlightReservation.Contract.Interfaces;
using Peerislands.FlightReservation.DataContract.Messages;

namespace Peerislands.FlightReservation.Interactor
{
    public class BookFlightInteractor : IBookFlightInteractor
    {
        private readonly IBookFlightService _bookFlightService;

        public BookFlightInteractor(IBookFlightService bookFlightService)
        {
            _bookFlightService = bookFlightService;
        }
        public async Task<BookFlightResponse> BookFlightAsync(BookFlightRequest bookFlightRequest)
        {
            if (bookFlightRequest == null)
                throw new ArgumentNullException(nameof(bookFlightRequest));
            return await _bookFlightService.BookFlight(bookFlightRequest);
        }
    }
}
