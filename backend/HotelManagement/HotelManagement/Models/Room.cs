﻿using HotelManagement.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HotelManagement.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public int Identifier { get; set; }
        public RoomType RoomType { get; set; }

        [NotMapped] 
        public int MaxOccupancy
        {
            get
            {
                switch (RoomType)
                {
                    case RoomType.Single:
                        return 1;
                    case RoomType.Double:
                        return 2;
                    case RoomType.Triple:
                        return 3;
                    case RoomType.Quad:
                        return 4;
                    default:
                        throw new InvalidOperationException("Invalid room type.");
                }
            }
        }

        [Required]
        public RoomStatus RoomStatus { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
       
    }

}
