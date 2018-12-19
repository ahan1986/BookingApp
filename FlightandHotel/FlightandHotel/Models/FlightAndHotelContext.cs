using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FlightandHotel.Models
{
    public class FlightAndHotelContext : DbContext
    {
        public FlightAndHotelContext (DbContextOptions<FlightAndHotelContext> options) : base (options) { }

        public DbSet<FlightandHotel.Models.FlightAndHotel> FlightAndHotel { get; set; }
    }
}
