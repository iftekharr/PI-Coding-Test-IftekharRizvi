using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Peerislands.FlightReservation.DataContract.Models;

public partial class AirportDbContext : DbContext
{
    public AirportDbContext()
    {
    }

    public AirportDbContext(DbContextOptions<AirportDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Airline> Airlines { get; set; }

    public virtual DbSet<Airplane> Airplanes { get; set; }

    public virtual DbSet<AirplaneType> AirplaneTypes { get; set; }

    public virtual DbSet<Airport> Airports { get; set; }

    public virtual DbSet<AirportGeo> AirportGeos { get; set; }

    public virtual DbSet<AirportReachable> AirportReachables { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<FlightLog> FlightLogs { get; set; }

    public virtual DbSet<Flightschedule> Flightschedules { get; set; }

    public virtual DbSet<Passenger> Passengers { get; set; }

    public virtual DbSet<Passengerdetail> Passengerdetails { get; set; }

    public virtual DbSet<Weatherdatum> Weatherdata { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-29738MQ2\\MSSQL2022;Database=AirportDB;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Airline>(entity =>
        {
            entity.HasKey(e => e.AirlineId).HasName("PK_airline_airline_id");

            entity.ToTable("airline", "airportdb");

            entity.HasIndex(e => e.Iata, "airline$iata_unq").IsUnique();

            entity.HasIndex(e => e.BaseAirport, "base_airport_idx");

            entity.Property(e => e.AirlineId).HasColumnName("airline_id");
            entity.Property(e => e.Airlinename)
                .HasMaxLength(30)
                .HasColumnName("airlinename");
            entity.Property(e => e.BaseAirport).HasColumnName("base_airport");
            entity.Property(e => e.Iata)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("iata");

            entity.HasOne(d => d.BaseAirportNavigation).WithMany(p => p.Airlines)
                .HasForeignKey(d => d.BaseAirport)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("airline$airline_ibfk_1");
        });

        modelBuilder.Entity<Airplane>(entity =>
        {
            entity.HasKey(e => e.AirplaneId).HasName("PK_airplane_airplane_id");

            entity.ToTable("airplane", "airportdb");

            entity.HasIndex(e => e.TypeId, "type_id");

            entity.Property(e => e.AirplaneId).HasColumnName("airplane_id");
            entity.Property(e => e.AirlineId).HasColumnName("airline_id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.TypeId).HasColumnName("type_id");

            entity.HasOne(d => d.Type).WithMany(p => p.Airplanes)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("airplane$airplane_ibfk_1");
        });

        modelBuilder.Entity<AirplaneType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK_airplane_type_type_id");

            entity.ToTable("airplane_type", "airportdb");

            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Identifier)
                .HasMaxLength(50)
                .HasColumnName("identifier");
        });

        modelBuilder.Entity<Airport>(entity =>
        {
            entity.HasKey(e => e.AirportId).HasName("PK_airport_airport_id");

            entity.ToTable("airport", "airportdb");

            entity.HasIndex(e => e.Icao, "airport$icao_unq").IsUnique();

            entity.HasIndex(e => e.Iata, "iata_idx");

            entity.HasIndex(e => e.Name, "name_idx");

            entity.Property(e => e.AirportId).HasColumnName("airport_id");
            entity.Property(e => e.Iata)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("iata");
            entity.Property(e => e.Icao)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("icao");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<AirportGeo>(entity =>
        {
            entity.HasKey(e => e.AirportId).HasName("PK_airport_geo_airport_id");

            entity.ToTable("airport_geo", "airportdb");

            entity.Property(e => e.AirportId)
                .ValueGeneratedNever()
                .HasColumnName("airport_id");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.Latitude)
                .HasColumnType("decimal(11, 8)")
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasColumnType("decimal(11, 8)")
                .HasColumnName("longitude");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.Airport).WithOne(p => p.AirportGeo)
                .HasForeignKey<AirportGeo>(d => d.AirportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("airport_geo$airport_geo_ibfk_1");
        });

        modelBuilder.Entity<AirportReachable>(entity =>
        {
            entity.HasKey(e => e.AirportId).HasName("PK_airport_reachable_airport_id");

            entity.ToTable("airport_reachable", "airportdb");

            entity.Property(e => e.AirportId)
                .ValueGeneratedNever()
                .HasColumnName("airport_id");
            entity.Property(e => e.Hops).HasColumnName("hops");

            entity.HasOne(d => d.Airport).WithOne(p => p.AirportReachable)
                .HasForeignKey<AirportReachable>(d => d.AirportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("airport_reachable$airport_reachable_ibfk_1");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK_booking_booking_id");

            entity.ToTable("booking", "airportdb");

            entity.HasIndex(e => new { e.FlightId, e.Seat }, "booking$seatplan_unq").IsUnique();

            entity.HasIndex(e => e.FlightId, "flight_idx");

            entity.HasIndex(e => e.PassengerId, "passenger_idx");

            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.FlightId).HasColumnName("flight_id");
            entity.Property(e => e.OrderId).HasColumnName("OrderId");
            entity.Property(e => e.PassengerId).HasColumnName("passenger_id");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Seat)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("seat");

            entity.HasOne(d => d.Flight).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.FlightId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("booking$booking_ibfk_1");

            entity.HasOne(d => d.Passenger).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.PassengerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("booking$booking_ibfk_2");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK_employee_employee_id");

            entity.ToTable("employee", "airportdb");

            entity.HasIndex(e => e.Username, "employee$user_unq").IsUnique();

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Birthdate)
                .HasColumnType("date")
                .HasColumnName("birthdate");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.Department)
                .HasMaxLength(11)
                .HasColumnName("department");
            entity.Property(e => e.Emailaddress)
                .HasMaxLength(120)
                .HasColumnName("emailaddress");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.Password)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("password");
            entity.Property(e => e.Salary)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("salary");
            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("sex");
            entity.Property(e => e.Street)
                .HasMaxLength(100)
                .HasColumnName("street");
            entity.Property(e => e.Telephoneno)
                .HasMaxLength(30)
                .HasColumnName("telephoneno");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasColumnName("username");
            entity.Property(e => e.Zip).HasColumnName("zip");
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.FlightId).HasName("PK_flight_flight_id");

            entity.ToTable("flight", "airportdb");

            entity.HasIndex(e => e.AirlineId, "airline_idx");

            entity.HasIndex(e => e.AirplaneId, "airplane_idx");

            entity.HasIndex(e => e.Arrival, "arrivals_idx");

            entity.HasIndex(e => e.Departure, "departure_idx");

            entity.HasIndex(e => e.Flightno, "flightno");

            entity.HasIndex(e => e.From, "from_idx");

            entity.HasIndex(e => e.To, "to_idx");

            entity.Property(e => e.FlightId).HasColumnName("flight_id");
            entity.Property(e => e.AirlineId).HasColumnName("airline_id");
            entity.Property(e => e.AirplaneId).HasColumnName("airplane_id");
            entity.Property(e => e.Arrival)
                .HasPrecision(0)
                .HasColumnName("arrival");
            entity.Property(e => e.Departure)
                .HasPrecision(0)
                .HasColumnName("departure");
            entity.Property(e => e.Flightno)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("flightno");
            entity.Property(e => e.From).HasColumnName("from");
            entity.Property(e => e.To).HasColumnName("to");

            entity.HasOne(d => d.Airline).WithMany(p => p.Flights)
                .HasForeignKey(d => d.AirlineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("flight$flight_ibfk_3");

            entity.HasOne(d => d.Airplane).WithMany(p => p.Flights)
                .HasForeignKey(d => d.AirplaneId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("flight$flight_ibfk_4");

            entity.HasOne(d => d.FlightnoNavigation).WithMany(p => p.Flights)
                .HasForeignKey(d => d.Flightno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("flight$flight_ibfk_5");

            entity.HasOne(d => d.FromNavigation).WithMany(p => p.FlightFromNavigations)
                .HasForeignKey(d => d.From)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("flight$flight_ibfk_1");

            entity.HasOne(d => d.ToNavigation).WithMany(p => p.FlightToNavigations)
                .HasForeignKey(d => d.To)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("flight$flight_ibfk_2");
        });

        modelBuilder.Entity<FlightLog>(entity =>
        {
            entity.HasKey(e => e.FlightLogId).HasName("PK_flight_log_flight_log_id");

            entity.ToTable("flight_log", "airportdb");

            entity.HasIndex(e => e.FlightId, "flight_log_ibfk_1");

            entity.Property(e => e.FlightLogId).HasColumnName("flight_log_id");
            entity.Property(e => e.AirlineIdNew).HasColumnName("airline_id_new");
            entity.Property(e => e.AirlineIdOld).HasColumnName("airline_id_old");
            entity.Property(e => e.AirplaneIdNew).HasColumnName("airplane_id_new");
            entity.Property(e => e.AirplaneIdOld).HasColumnName("airplane_id_old");
            entity.Property(e => e.ArrivalNew)
                .HasPrecision(0)
                .HasColumnName("arrival_new");
            entity.Property(e => e.ArrivalOld)
                .HasPrecision(0)
                .HasColumnName("arrival_old");
            entity.Property(e => e.Comment)
                .HasMaxLength(200)
                .HasColumnName("comment");
            entity.Property(e => e.DepartureNew)
                .HasPrecision(0)
                .HasColumnName("departure_new");
            entity.Property(e => e.DepartureOld)
                .HasPrecision(0)
                .HasColumnName("departure_old");
            entity.Property(e => e.FlightId).HasColumnName("flight_id");
            entity.Property(e => e.FlightnoNew)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("flightno_new");
            entity.Property(e => e.FlightnoOld)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("flightno_old");
            entity.Property(e => e.FromNew).HasColumnName("from_new");
            entity.Property(e => e.FromOld).HasColumnName("from_old");
            entity.Property(e => e.LogDate)
                .HasPrecision(0)
                .HasColumnName("log_date");
            entity.Property(e => e.ToNew).HasColumnName("to_new");
            entity.Property(e => e.ToOld).HasColumnName("to_old");
            entity.Property(e => e.User)
                .HasMaxLength(100)
                .HasColumnName("user");

            entity.HasOne(d => d.Flight).WithMany(p => p.FlightLogs)
                .HasForeignKey(d => d.FlightId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("flight_log$flight_log_ibfk_1");
        });

        modelBuilder.Entity<Flightschedule>(entity =>
        {
            entity.HasKey(e => e.Flightno).HasName("PK_flightschedule_flightno");

            entity.ToTable("flightschedule", "airportdb");

            entity.HasIndex(e => e.AirlineId, "airline_idx");

            entity.HasIndex(e => e.From, "from_idx");

            entity.HasIndex(e => e.To, "to_idx");

            entity.Property(e => e.Flightno)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("flightno");
            entity.Property(e => e.AirlineId).HasColumnName("airline_id");
            entity.Property(e => e.Arrival).HasColumnName("arrival");
            entity.Property(e => e.Departure).HasColumnName("departure");
            entity.Property(e => e.Friday)
                .HasDefaultValueSql("((0))")
                .HasColumnName("friday");
            entity.Property(e => e.From).HasColumnName("from");
            entity.Property(e => e.Monday)
                .HasDefaultValueSql("((0))")
                .HasColumnName("monday");
            entity.Property(e => e.Saturday)
                .HasDefaultValueSql("((0))")
                .HasColumnName("saturday");
            entity.Property(e => e.Sunday)
                .HasDefaultValueSql("((0))")
                .HasColumnName("sunday");
            entity.Property(e => e.Thursday)
                .HasDefaultValueSql("((0))")
                .HasColumnName("thursday");
            entity.Property(e => e.To).HasColumnName("to");
            entity.Property(e => e.Tuesday)
                .HasDefaultValueSql("((0))")
                .HasColumnName("tuesday");
            entity.Property(e => e.Wednesday)
                .HasDefaultValueSql("((0))")
                .HasColumnName("wednesday");

            entity.HasOne(d => d.Airline).WithMany(p => p.Flightschedules)
                .HasForeignKey(d => d.AirlineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("flightschedule$flightschedule_ibfk_3");

            entity.HasOne(d => d.FromNavigation).WithMany(p => p.FlightscheduleFromNavigations)
                .HasForeignKey(d => d.From)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("flightschedule$flightschedule_ibfk_1");

            entity.HasOne(d => d.ToNavigation).WithMany(p => p.FlightscheduleToNavigations)
                .HasForeignKey(d => d.To)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("flightschedule$flightschedule_ibfk_2");
        });

        modelBuilder.Entity<Passenger>(entity =>
        {
            entity.HasKey(e => e.PassengerId).HasName("PK_passenger_passenger_id");

            entity.ToTable("passenger", "airportdb");

            entity.HasIndex(e => e.Passportno, "passenger$pass_unq").IsUnique();

            entity.Property(e => e.PassengerId).HasColumnName("passenger_id");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.Passportno)
                .HasMaxLength(9)
                .IsFixedLength()
                .HasColumnName("passportno");
        });

        modelBuilder.Entity<Passengerdetail>(entity =>
        {
            entity.HasKey(e => e.PassengerId).HasName("PK_passengerdetails_passenger_id");

            entity.ToTable("passengerdetails", "airportdb");

            entity.Property(e => e.PassengerId)
                .ValueGeneratedNever()
                .HasColumnName("passenger_id");
            entity.Property(e => e.Birthdate)
                .HasColumnType("date")
                .HasColumnName("birthdate");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.Emailaddress)
                .HasMaxLength(120)
                .HasColumnName("emailaddress");
            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("sex");
            entity.Property(e => e.Street)
                .HasMaxLength(100)
                .HasColumnName("street");
            entity.Property(e => e.Telephoneno)
                .HasMaxLength(30)
                .HasColumnName("telephoneno");
            entity.Property(e => e.Zip).HasColumnName("zip");

            entity.HasOne(d => d.Passenger).WithOne(p => p.Passengerdetail)
                .HasForeignKey<Passengerdetail>(d => d.PassengerId)
                .HasConstraintName("passengerdetails$passengerdetails_ibfk_1");
        });

        modelBuilder.Entity<Weatherdatum>(entity =>
        {
            entity.HasKey(e => new { e.LogDate, e.Time, e.Station }).HasName("PK_weatherdata_log_date");

            entity.ToTable("weatherdata", "airportdb");

            entity.Property(e => e.LogDate)
                .HasColumnType("date")
                .HasColumnName("log_date");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.Station).HasColumnName("station");
            entity.Property(e => e.Airpressure)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("airpressure");
            entity.Property(e => e.Humidity)
                .HasColumnType("decimal(4, 1)")
                .HasColumnName("humidity");
            entity.Property(e => e.Temp)
                .HasColumnType("decimal(3, 1)")
                .HasColumnName("temp");
            entity.Property(e => e.Weather)
                .HasMaxLength(20)
                .HasColumnName("weather");
            entity.Property(e => e.Wind)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("wind");
            entity.Property(e => e.Winddirection).HasColumnName("winddirection");
        });

#pragma warning disable S3251 // Implementations should be provided for "partial" methods
        OnModelCreatingPartial(modelBuilder);
#pragma warning restore S3251 // Implementations should be provided for "partial" methods
    }

#pragma warning disable S3251 // Implementations should be provided for "partial" methods
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
#pragma warning restore S3251 // Implementations should be provided for "partial" methods
}
