namespace Peerislands.FlightReservation.DataContract.Models;

public partial class AirportReachable
{
    public short AirportId { get; set; }

    public int? Hops { get; set; }

    public virtual Airport Airport { get; set; } = null!;
}
