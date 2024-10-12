using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TravelBookingSystem.Models
{
    public class TravelSystemContext : IdentityDbContext<ApplicationUser>
    {
       public DbSet<Flight> Flights { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public TravelSystemContext(DbContextOptions options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-I7PU4G3;Database=TravelBookingSystem;Trusted_Connection=True;Encrypt=false");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                .Property(f => f.Price)
                .HasColumnType("decimal(5,2)"); // دقة 18 وأرقام عشرية 2

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasKey(p => new { p.UserId, p.RoleId });

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(p => new { p.LoginProvider, p.ProviderKey });

            modelBuilder.Entity<IdentityUserToken<string>>()
                .HasKey(p => new { p.UserId, p.LoginProvider, p.Name });
        }


    }
}
