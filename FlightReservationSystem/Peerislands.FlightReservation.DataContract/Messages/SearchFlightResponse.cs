namespace Peerislands.FlightReservation.DataContract.Messages
{
    public class SearchFlightResponse
    {
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public string? FlightNo { get; set; }
        public TimeSpan? DepartureTime { get; set; }
        public TimeSpan? ArrivalTime { get; set; }
        public string? AirLineName { get; set; }
        public string? Message { get; set; }
    }
}
