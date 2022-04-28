﻿using System.Collections.Generic;

namespace Inn_Management_System.Models.DTO
{
    public class HotelDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public List<HotelRoomDTO> Rooms { get; set; }
    }
}
