namespace HotelManagement.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }       

        public ICollection<Room> Rooms { get; set; }
    }
}
