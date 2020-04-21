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
    }
}
