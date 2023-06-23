﻿using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        [Required]
        public DateTime PlacedDate { get; set; }

        [Required]
        public DateTime BookingStart { get; set; }

        [Required]
        public DateTime BookingEnd { get; set; }

        public int? ThirdPartyId { get; set; }
        public int CustomerId { get; set; } 
        public Customer Customer { get; set; }
        public ICollection<BookingRoom> BookingRooms { get; set; }
    }
}
