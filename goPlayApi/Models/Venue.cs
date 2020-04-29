using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goPlayApi.Models
{
    public class Venue
    {
        public int VenueId { get; set; }
        public String VenueName { get; set; }
        public String Address { get; set; }
        public String Number { get; set; }
        public String  Image { get; set; }
        public double Ratings { get; set; } = 0.0;
        public int RatingCount { get; set; } = 0;
        public double Amount { get; set; } = 0.0;
        public String Description { get; set; }
        public String TimeSlot { get; set; }
        public List<VenuesImage> VenueImages { get; set; }
    }
}
