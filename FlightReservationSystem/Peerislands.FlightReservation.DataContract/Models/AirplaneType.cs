using System;
using System.Collections.Generic;

namespace Peerislands.FlightReservation.DataContract.Models;

public partial class AirplaneType
{
    public int TypeId { get; set; }

    public string? Identifier { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Airplane> Airplanes { get; set; } = new List<Airplane>();
}
