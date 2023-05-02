namespace Peerislands.FlightReservation.DataContract.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public DateTime Birthdate { get; set; }

    public string? Sex { get; set; }

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public short Zip { get; set; }

    public string Country { get; set; } = null!;

    public string? Emailaddress { get; set; }

    public string? Telephoneno { get; set; }

    public decimal? Salary { get; set; }

    public string? Department { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }
}
