using Microsoft.EntityFrameworkCore;

namespace FlightandHotel.Models
{
    //extend this off with DbContext
    public class FlightAndHotelContext : DbContext
    {
        public FlightAndHotelContext (DbContextOptions<FlightAndHotelContext> options) : base (options) { }
        // using the flightandhotel model and using it as our DbSet
        public DbSet<FlightandHotel.Models.FlightAndHotel> FlightAndHotel { get; set; }
    }
}
