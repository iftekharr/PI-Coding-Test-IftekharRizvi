using Peerislands.FlightReservation.DataContract.Messages;

namespace Peerislands.FlightReservation.UnitTests.TestDataProvider
{
    public static class SearchFlightMockDataProvider
    {
        public static SearchFlightRequest GetSearchFlightRequest()
        {
            return new SearchFlightRequest
            {
                DepartureLocation = "WIC",
                ArrivalLocation = "PKK",
                DepartureDate = Convert.ToDateTime("2023-05-15T17:16:40"),
                NumberOfPassengers = 1,
            };
        }

        public static SearchFlightResponse GetSearchFlightResponse()
        {
            return new SearchFlightResponse
            {
                Origin = "WICK",
                Destination = "PAKHOKKU",
                FlightNo = "UN1017",
                DepartureTime = new TimeSpan(2, 9, 0),
                ArrivalTime = new TimeSpan(12, 26, 00),
                AirLineName = "United Arab Emirates"
            };
        }
    }
}