using HotelManagement.Models;

namespace HotelManagement.Services
{
    public interface IBookingDetailService
    {
        Task<List<BookingDetail>> GetAllBookingDetailsAsync();
        Task<BookingDetail?> GetBookingDetailByIdAsync(int bookingDetailId);
        BookingDetail CreateBookingDetail(BookingDetail bookingDetail);
        Task<bool> UpdateBookingDetailAsync(BookingDetail bookingDetail);
        Task<bool> DeleteBookingDetailAsync(int bookingDetailId);
    }

}
