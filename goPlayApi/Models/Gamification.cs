using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goPlayApi.Models
{
    public class Gamification
    {
        public int GamificationId { get; set; }
        public int Points { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
