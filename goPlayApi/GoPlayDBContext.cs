using goPlayApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goPlayApi
{
    public class GoPlayDBContext:DbContext
    {
        public GoPlayDBContext(DbContextOptions<GoPlayDBContext> options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Gamification> Gamification { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<VenuesImage> VenuesImages { get; set; }
    }
}
