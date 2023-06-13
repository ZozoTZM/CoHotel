using HotelManagement.Data;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Services
{
    public class BookingDetailService : IBookingDetailService
    {
        private readonly HotelManagementContext _context;

        public BookingDetailService(HotelManagementContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<List<BookingDetail>> GetAllBookingDetailsAsync()
        {
            return await _context.BookingDetails.ToListAsync();
        }
        public async Task<BookingDetail?> GetBookingDetailByIdAsync(int bookingDetailId)
        {
            return await _context.BookingDetails.FindAsync(bookingDetailId);
        }
        public BookingDetail CreateBookingDetail(BookingDetail bookingDetail)
        {           
            _context.BookingDetails.Add(bookingDetail);
            _context.SaveChanges();

            return bookingDetail;
        }
        public async Task<bool> UpdateBookingDetailAsync(BookingDetail bookingDetail)
        {
            _context.Entry(bookingDetail).State = EntityState.Modified;
            int affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<bool> DeleteBookingDetailAsync(int bookingDetailId)
        {
            var bookingDetail = await _context.BookingDetails.FindAsync(bookingDetailId);
            if (bookingDetail != null)
            {
                _context.BookingDetails.Remove(bookingDetail);
                int affectedRows = await _context.SaveChangesAsync();
                return affectedRows > 0;
            }
            return false;
        }
    }
}
