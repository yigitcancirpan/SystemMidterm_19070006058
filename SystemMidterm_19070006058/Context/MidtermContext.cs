using Microsoft.EntityFrameworkCore;
using SystemMidterm_19070006058.Model;

namespace SystemMidterm_19070006058.Context
{
    public class MidtermContext:DbContext
    {
        public MidtermContext(DbContextOptions options):base(options) 
        {

        }
        public DbSet<House> Houses { get; set; }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<Booking>? Booking { get; set; }
        public DbSet<Amenity>? Amenity { get; set; }
        public DbSet<AmenityHouse>? AmenityHouse { get;set; }

    }
}
