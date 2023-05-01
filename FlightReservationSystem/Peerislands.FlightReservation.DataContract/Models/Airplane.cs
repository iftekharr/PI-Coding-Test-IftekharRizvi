using System;
using System.Collections.Generic;

namespace Peerislands.FlightReservation.DataContract.Models;

public partial class Airplane
{
    public int AirplaneId { get; set; }

    public int Capacity { get; set; }

    public int TypeId { get; set; }

    public int AirlineId { get; set; }

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();

    public virtual AirplaneType Type { get; set; } = null!;
}
