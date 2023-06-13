using HotelManagement.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HotelManagement.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RoomType RoomType { get; set; }
        [Required]
        public int MaxOccupancy { get; set; }
        public int CurrOccupancy { get; set; }
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RoomStatus RoomStatus { get; set; }

    }
}
