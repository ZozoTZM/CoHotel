using HotelManagement.Models.Enums;

namespace HotelManagement.DTOs
{
    public class RoomDTO
    {       
        public int Identifier { get; set; }
        public RoomType RoomType { get; set; }
        public RoomStatus RoomStatus { get; set; }
        public int HotelId { get; set; }
    }

}
