using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace goPlayApi.Models
{
    public class VenuesImage
    {
        [Key]
        public int VenueImageId { get; set; }
        public String VenueImage { get; set; }
        public int VenueId { get; set; }
    }
}
