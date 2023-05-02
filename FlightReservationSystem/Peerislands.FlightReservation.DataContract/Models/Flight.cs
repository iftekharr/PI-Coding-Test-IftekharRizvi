namespace Peerislands.FlightReservation.DataContract.Models;

public partial class Flight
{
    public int FlightId { get; set; }

    public string Flightno { get; set; } = null!;

    public short From { get; set; }

    public short To { get; set; }

    public DateTime Departure { get; set; }

    public DateTime Arrival { get; set; }

    public short AirlineId { get; set; }

    public int AirplaneId { get; set; }

    public virtual Airline Airline { get; set; } = null!;

    public virtual Airplane Airplane { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<FlightLog> FlightLogs { get; set; } = new List<FlightLog>();

    public virtual Flightschedule FlightnoNavigation { get; set; } = null!;

    public virtual Airport FromNavigation { get; set; } = null!;

    public virtual Airport ToNavigation { get; set; } = null!;
}
