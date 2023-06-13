using HotelManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.Services
{
    public interface IBookingService
    {
        Task<List<Booking>> GetAllBookings();
        Task<Booking?> GetBookingByIdAsync(int bookingId);
        Task<Booking> GetBookingByThirdPartyIdAsync(int thirdPartyId);
        public Booking CreateBooking(Booking booking);
        Task<bool> UpdateBookingAsync(Booking booking);
        Task<bool> DeleteBookingAsync(int bookingId);
    }

}
