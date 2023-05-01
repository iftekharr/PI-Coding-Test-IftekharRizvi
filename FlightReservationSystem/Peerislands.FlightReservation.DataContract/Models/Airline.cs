using System;
using System.Collections.Generic;

namespace Peerislands.FlightReservation.DataContract.Models;

public partial class Airline
{
    public short AirlineId { get; set; }

    public string Iata { get; set; } = null!;

    public string? Airlinename { get; set; }

    public short BaseAirport { get; set; }

    public virtual Airport BaseAirportNavigation { get; set; } = null!;

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();

    public virtual ICollection<Flightschedule> Flightschedules { get; set; } = new List<Flightschedule>();
}
