namespace Peerislands.FlightReservation.DataContract.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int FlightId { get; set; }

    public string? Seat { get; set; }

    public int PassengerId { get; set; }

    public decimal Price { get; set; }

    public virtual Flight Flight { get; set; } = null!;

    public virtual Passenger Passenger { get; set; } = null!;
}
