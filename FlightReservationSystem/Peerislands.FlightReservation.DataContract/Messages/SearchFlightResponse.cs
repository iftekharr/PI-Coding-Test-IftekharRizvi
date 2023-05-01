using Peerislands.FlightReservation.DataContract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peerislands.FlightReservation.DataContract.Messages
{
    public class SearchFlightResponse
    {
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public string? FlightNo { get; set; }
        public TimeSpan? DepartureTime { get; set; }
        public TimeSpan? ArrivalTime { get; set; }
        public string? AirLineName { get; set; }
    }
}
