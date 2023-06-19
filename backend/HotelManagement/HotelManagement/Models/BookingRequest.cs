namespace HotelManagement.Models
{
    public class BookingRequest
    {
        public Customer Customer { get; set; }
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
        public int? ThirdPartyId { get; set; }
        public List<int> RoomNumbers { get; set; }
    }
}
