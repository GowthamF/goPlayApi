using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goPlayApi.Models
{
    public class Promotion
    {
        public int PromotionId { get; set; }
        public String PromotionName { get; set; }
        public String PromotionPictures { get; set; }
        public String Description { get; set; }
        public int PromotionAmount { get; set; }
        public int VenueId { get; set; }
        public Venue Venue { get; set; }
    }
}
