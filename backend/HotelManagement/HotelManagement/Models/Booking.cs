namespace HotelManagement.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime BookingPlaced { get; set; }
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set;}
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public int ThirdPartyId { get; set; }
        public ICollection<BookingDetail> BookingDetails { get; set; } = null!;
    }
}
