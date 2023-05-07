using Peerislands.FlightReservation.DataContract.Messages;
using Peerislands.FlightReservation.DataContract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Peerislands.FlightReservation.Services
{
    public static class Translator
    {
        public static Passenger ToPassenger(this BookFlightRequest bookFlightRequest)
        {
            return new()
            {
                Passportno = bookFlightRequest.PassportNo,
                Firstname = bookFlightRequest.Firstname,
                Lastname = bookFlightRequest.Lastname,
                Passengerdetail = ToPassengerDetails(bookFlightRequest),
            };
        }
        private static Passengerdetail ToPassengerDetails(BookFlightRequest bookFlightRequest)
        {
            return new()
            {
                Birthdate = bookFlightRequest.Birthdate,
                Street = bookFlightRequest.Street,
                Sex = bookFlightRequest.Sex,
                Telephoneno = bookFlightRequest.Telephoneno,
                Country = bookFlightRequest.Country,
                Emailaddress = bookFlightRequest.Emailaddress,
                City = bookFlightRequest.City,
                Zip = bookFlightRequest.Zip
            };
        }
        public static Booking ToBookingDetails(this BookFlightRequest bookFlightRequest, int flightId, int passengerId)
        {
            return new()
            {
                FlightId = flightId,
                PassengerId = passengerId,
                Seat = bookFlightRequest.SeatNo,
                Price = bookFlightRequest.Price,
                OrderId = Guid.NewGuid().ToString()
            };
        }
    }
}
