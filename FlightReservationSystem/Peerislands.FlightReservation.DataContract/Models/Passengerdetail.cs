using System;
using System.Collections.Generic;

namespace Peerislands.FlightReservation.DataContract.Models;

public partial class Passengerdetail
{
    public int PassengerId { get; set; }

    public DateTime Birthdate { get; set; }

    public string? Sex { get; set; }

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public short Zip { get; set; }

    public string Country { get; set; } = null!;

    public string? Emailaddress { get; set; }

    public string? Telephoneno { get; set; }

    public virtual Passenger Passenger { get; set; } = null!;
}
