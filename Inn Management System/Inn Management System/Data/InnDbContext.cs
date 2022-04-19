using Inn_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Inn_Management_System.Data
{
    public class InnDbContext : DbContext
    {
        public InnDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
               .HasData(new Hotel { ID = 1, Name = "Inn-IRBID", Address = "IRBID", State = "jordan", Phone = "096226521" },
                        new Hotel { ID = 2, Name = "Inn-JERASH", Address = "JERASH", State = "jordan", Phone = "096226522" },
                        new Hotel { ID = 3, Name = "Inn-UMM QAIS", Address = "UMM QAIS", State = "jordan", Phone = "096226523" }
                        );
            modelBuilder.Entity<Room>()
          .HasData(new Room { ID = 1, Name = "studio", Layout = 0 },
                   new Room { ID = 2, Name = "one bedroom", Layout = 1 },
                   new Room { ID = 3, Name = "2 bedrooms", Layout = 2 }
                   );

            modelBuilder.Entity<Amenity>()
                .HasData(new Amenity { ID = 1, Name = "conditions" },                        
                         new Amenity { ID = 3, Name = "Animals are allowed" },
                          new Amenity { ID = 2, Name = "coffee maker" }


                         );



        }
    }
}
