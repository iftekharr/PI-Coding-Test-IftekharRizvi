namespace Peerislands.FlightReservation.DataContract.Messages
{
    public class BookFlightRequest
    {
        public string PassportNo { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public DateTime Birthdate { get; set; }
        public string Sex { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public short Zip { get; set; }
        public string Country { get; set; } = null!;
        public string? Emailaddress { get; set; }
        public string Telephoneno { get; set; } = null!;
        public string FlightNo { get; set; } = null!;
        public string? SeatNo { get; set; }
        public decimal Price { get; set; }
    }
}