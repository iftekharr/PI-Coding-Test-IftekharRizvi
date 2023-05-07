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

            var flightSchedule = GetFlightSchedules(fromOriginAirport?.AirportId, toDestinationAirport?.AirportId, searchFlightRequest.DepartureDate);

            if(flightSchedule?.Count > 0)
            {
                var flightNo = flightSchedule.Select(i => i.Flightno).FirstOrDefault();

                var airlineName = GetAirlineName(flightSchedule.Select(i => i.AirlineId).FirstOrDefault());

                var departureTime = flightSchedule.Select(i => i.Departure).FirstOrDefault();

                var arrivalTime = flightSchedule.Select(i => i.Arrival).FirstOrDefault();

                return ToSearchFlightResponse(fromOriginAirport?.Name, toDestinationAirport?.Name, flightNo, airlineName.Result, departureTime, arrivalTime);
            }
            return ToSearchFlightResponse(fromOriginAirport?.Name, toDestinationAirport?.Name, flightNo: null, airlineName: null, null, null);
        }

        private async Task<string> GetAirlineName(short airlineId)
        {
            var airline = await _context.Airlines.FindAsync(airlineId);
            return airline.Airlinename = null!;
        }

        private static SearchFlightResponse ToSearchFlightResponse(string? fromOriginAirport, string? toDestinationAirport, string? flightNo, string? airlineName, TimeSpan? departureTime, TimeSpan? arrivalTime)
        {
            SearchFlightResponse searchFlightResponse = new();
            if(flightNo != null)
            {
                searchFlightResponse.Origin = fromOriginAirport;
                searchFlightResponse.Destination = toDestinationAirport;
                searchFlightResponse.FlightNo = flightNo;
                searchFlightResponse.DepartureTime = departureTime;
                searchFlightResponse.ArrivalTime = arrivalTime;
                searchFlightResponse.AirLineName = airlineName;
            }
            else
            {
                searchFlightResponse.Message = "No flights are available for this date.";
            }
            return searchFlightResponse;
        }

        private List<Flightschedule> GetFlightSchedules(short? fromOriginAirport, short? toDestinationAirport, DateTime departureDate)
        {
            var dayOfWeek = departureDate.DayOfWeek;
            var flightScehdules = _context.Flightschedules
                .Where(i => i.From == fromOriginAirport && i.To == toDestinationAirport)
                .ToList();
            return FindFlightScheduleOnDayOfWeek(dayOfWeek, flightScehdules);
        }

        private static List<Flightschedule> FindFlightScheduleOnDayOfWeek(DayOfWeek dayOfWeek, List<Flightschedule> flightScehdules)
        {
            List<Flightschedule> newFlightschedules = new();
            foreach (var item in flightScehdules)
            {
                switch (dayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        if(item.Sunday == 1)
                            newFlightschedules.Add(item);
                        break;
                    case DayOfWeek.Monday:
                        if (item.Monday == 1)
                            newFlightschedules.Add(item);
                        break;
                    case DayOfWeek.Tuesday:
                        if (item.Tuesday == 1)
                            newFlightschedules.Add(item);
                        break;
                    case DayOfWeek.Wednesday:
                        if (item.Wednesday == 1)
                            newFlightschedules.Add(item);
                        break;
                    case DayOfWeek.Thursday:
                        if (item.Thursday == 1)
                            newFlightschedules.Add(item);
                        break;
                    case DayOfWeek.Friday:
                        if (item.Friday == 1)
                            newFlightschedules.Add(item);
                        break;
                    case DayOfWeek.Saturday:
                        if (item.Saturday == 1)
                            newFlightschedules.Add(item);
                        break;
                    default:
                        return flightScehdules;
                }
            }
            return newFlightschedules;
        }
    }
}
