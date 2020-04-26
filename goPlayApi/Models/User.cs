using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goPlayApi.Models
{
    public class User
    {
        public int UserId { get; set; }
        public String UserFirstName { get; set; }
        public String UserLastName { get; set; }
        public String Password { get; set; }
        public String EmailAddress { get; set; }
        public Gamification Gamification { get; set; }
    }
}
