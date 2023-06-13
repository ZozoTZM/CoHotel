using HotelManagement.Data;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Services
{
    public class BookingService : IBookingService
    {
        private readonly HotelManagementContext _context;

        public BookingService(HotelManagementContext context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetAllBookings()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<Booking?> GetBookingByIdAsync(int bookingId)
        {
            return await _context.Bookings.FindAsync(bookingId);
        }
        public async Task<Booking?> GetBookingByThirdPartyIdAsync(int thirdPartyId)
        {
            return await _context.Bookings.FirstOrDefaultAsync(b => b.ThirdPartyId == thirdPartyId);
        }

        public Booking CreateBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return booking;
        }


        public async Task<bool> UpdateBookingAsync(Booking booking)
        {
            _context.Entry(booking).State = EntityState.Modified;
            int affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<bool> DeleteBookingAsync(int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                int affectedRows = await _context.SaveChangesAsync();
                return affectedRows > 0;
            }
            return false;
        }
    }
}
