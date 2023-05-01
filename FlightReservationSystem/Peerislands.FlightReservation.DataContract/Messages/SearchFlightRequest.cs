namespace Peerislands.FlightReservation.DataContract.Messages
{
    public class SearchFlightRequest
    {
        public string? DepartureLocation { get; set; }
        public string? ArrivalLocation { get; set; }
        public DateTime DepartureDate { get; set; }
        public int NumberOfPassengers { get; set; }
        public string? Airlines { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
    }
}
