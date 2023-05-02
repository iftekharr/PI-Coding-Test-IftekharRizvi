namespace Peerislands.FlightReservation.DataContract.Models;

public partial class Passenger
{
    public int PassengerId { get; set; }

    public string Passportno { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Passengerdetail? Passengerdetail { get; set; }
}
