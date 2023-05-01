using System;
using System.Collections.Generic;

namespace Peerislands.FlightReservation.DataContract.Models;

public partial class Weatherdatum
{
    public DateTime LogDate { get; set; }

    public TimeSpan Time { get; set; }

    public int Station { get; set; }

    public decimal Temp { get; set; }

    public decimal Humidity { get; set; }

    public decimal Airpressure { get; set; }

    public decimal Wind { get; set; }

    public string? Weather { get; set; }

    public short Winddirection { get; set; }
}
