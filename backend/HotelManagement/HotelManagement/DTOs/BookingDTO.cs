namespace HotelManagement.DTOs
{
    public class BookingDTO
    {
        public DateTime PlacedDate { get; set; }
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
        public int? ThirdPartyId { get; set; }       
        public List<int> RoomIdentifiers { get; set; }
    }

}
