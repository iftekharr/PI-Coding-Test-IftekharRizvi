namespace Peerislands.FlightReservation.DataContract.Models;

public partial class Flightschedule
{
    public string Flightno { get; set; } = null!;

    public short From { get; set; }

    public short To { get; set; }

    public TimeSpan Departure { get; set; }

    public TimeSpan Arrival { get; set; }

    public short AirlineId { get; set; }

    public short? Monday { get; set; }

    public short? Tuesday { get; set; }

    public short? Wednesday { get; set; }

    public short? Thursday { get; set; }

    public short? Friday { get; set; }

    public short? Saturday { get; set; }

    public short? Sunday { get; set; }

    public virtual Airline Airline { get; set; } = null!;

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();

    public virtual Airport FromNavigation { get; set; } = null!;

    public virtual Airport ToNavigation { get; set; } = null!;
}
