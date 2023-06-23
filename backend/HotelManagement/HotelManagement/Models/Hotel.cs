namespace HotelManagement.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        // Other hotel properties

        public ICollection<Room> Rooms { get; set; }
    }
}
