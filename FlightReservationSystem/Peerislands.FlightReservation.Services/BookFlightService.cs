using Peerislands.FlightReservation.Contract.Interfaces;
using Peerislands.FlightReservation.DataContract.Messages;
using Peerislands.FlightReservation.DataContract.Models;
using System.Runtime.CompilerServices;

namespace Peerislands.FlightReservation.Services
{
    public class BookFlightService : IBookFlightService
    {
        private readonly AirportDbContext _context;

        public BookFlightService(AirportDbContext context)
        {
            this._context = context;
        }
        public async Task<BookFlightResponse> BookFlight(BookFlightRequest bookFlightRequest)
        {
            BookFlightResponse bookFlightResponse = new();
            var passenger = bookFlightRequest.ToPassenger();
            var passengerId = await AddPassenger(passenger);

            var flightId = _context.Flights.Where(i => i.Flightno == bookFlightRequest.FlightNo).Select(i => i.FlightId).FirstOrDefault();

            var bookingDetails = bookFlightRequest.ToBookingDetails(flightId, passengerId);
            await AddBooking(bookingDetails);

            bookFlightResponse.OrderId = bookingDetails.OrderId;

            return bookFlightResponse;
        }
        private async Task<int> AddPassenger(Passenger passenger)
        {
            if (_context.Passengers == null)
                throw new ArgumentNullException(nameof(passenger));
            _context.Passengers.Add(passenger);
            await _context.SaveChangesAsync();
            return passenger.PassengerId;
        }
        private async Task AddBooking(Booking bookingDetails)
        {
            if (_context.Bookings == null)
                throw new ArgumentNullException(nameof(bookingDetails));
            _context.Bookings.Add(bookingDetails);
            await _context.SaveChangesAsync();
        }
    }
}
