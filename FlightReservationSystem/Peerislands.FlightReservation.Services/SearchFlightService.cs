using Peerislands.FlightReservation.Contract.Interfaces;
using Peerislands.FlightReservation.DataContract.Messages;
using Peerislands.FlightReservation.DataContract.Models;

namespace Peerislands.FlightReservation.Services
{
    public class SearchFlightService : ISearchFlightService
    {
        private readonly AirportDbContext _context;
        public SearchFlightService(AirportDbContext context)
        {
            this._context = context;
        }
        public async Task<SearchFlightResponse> SearchFlights(SearchFlightRequest searchFlightRequest)
        {
            if (searchFlightRequest == null)
                throw new ArgumentNullException(nameof(searchFlightRequest));

            var fromOriginAirport = _context.Airports.Where(i => i.Iata == searchFlightRequest.DepartureLocation).FirstOrDefault();

            var toDestinationAirport = _context.Airports.Where(i => i.Iata == searchFlightRequest.ArrivalLocation).FirstOrDefault();

            var flightSchedule = GetFlightSchedules(fromOriginAirport?.AirportId, toDestinationAirport?.AirportId);

            var flightNo = flightSchedule.Select(i => i.Flightno).FirstOrDefault();

            var airlineName = GetAirlineName(flightSchedule.Select(i => i.AirlineId).FirstOrDefault());

            var departureTime = flightSchedule.Select(i => i.Departure).FirstOrDefault();

            var arrivalTime = flightSchedule.Select(i => i.Arrival).FirstOrDefault();

            return ToSearchFlightResponse(fromOriginAirport?.Name, toDestinationAirport?.Name, flightNo, airlineName.Result, departureTime, arrivalTime);
        }

        private async Task<string> GetAirlineName(short airlineId)
        {
            var airline = await _context.Airlines.FindAsync(airlineId);
            return airline.Airlinename;
        }

        private static SearchFlightResponse ToSearchFlightResponse(string? fromOriginAirport, string? toDestinationAirport, string? flightNo, string? airlineName, TimeSpan departureTime, TimeSpan arrivalTime)
        {
            SearchFlightResponse searchFlightResponse = new()
            {
                Origin = fromOriginAirport,
                Destination = toDestinationAirport,
                FlightNo = flightNo,
                DepartureTime = departureTime,
                ArrivalTime = arrivalTime,
                AirLineName = airlineName
            };
            return searchFlightResponse;
        }

        private List<Flightschedule> GetFlightSchedules(short? fromOriginAirport, short? toDestinationAirport)
        {
            return _context.Flightschedules
                .Where(i => i.From == fromOriginAirport && i.To == toDestinationAirport)
                .ToList();
        }
    }
}
