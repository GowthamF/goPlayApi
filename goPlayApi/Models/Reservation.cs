using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goPlayApi.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int VenueId { get; set; }
        public Venue Venue { get; set; }
        public String TimeSlot { get; set; }
        public String SelectedDate { get; set; }
        public String Pitch { get; set; }
        public double Amount { get; set; }
    }
}
