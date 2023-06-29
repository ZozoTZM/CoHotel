using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data
{
    public class HotelManagementContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<BookingRoom> BookingRooms { get; set; } = null!;
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<User> Users { get; set; }
        public HotelManagementContext(DbContextOptions<HotelManagementContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingRoom>()
                .HasNoKey(); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
