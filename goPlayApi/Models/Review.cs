using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goPlayApi.Models
{
    public class Review
    {

        public int ReviewId { get; set; }
        public String ReviewComment { get; set; }
        public int VenueId { get; set; }
        public Venue Venue { get; set; }
    }
}
