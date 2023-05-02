namespace Peerislands.FlightReservation.DataContract.Models;

public partial class Airport
{
    public short AirportId { get; set; }

    public string? Iata { get; set; }

    public string Icao { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Airline> Airlines { get; set; } = new List<Airline>();

    public virtual AirportGeo? AirportGeo { get; set; }

    public virtual AirportReachable? AirportReachable { get; set; }

    public virtual ICollection<Flight> FlightFromNavigations { get; set; } = new List<Flight>();

    public virtual ICollection<Flight> FlightToNavigations { get; set; } = new List<Flight>();

    public virtual ICollection<Flightschedule> FlightscheduleFromNavigations { get; set; } = new List<Flightschedule>();

    public virtual ICollection<Flightschedule> FlightscheduleToNavigations { get; set; } = new List<Flightschedule>();
}
