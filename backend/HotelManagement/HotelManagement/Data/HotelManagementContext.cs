using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data
{
    public class HotelManagementContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<BookingDetail> BookingDetails { get; set; } = null!;
        public HotelManagementContext(DbContextOptions<HotelManagementContext> options) : base(options)
        {

        }      
    }
}
