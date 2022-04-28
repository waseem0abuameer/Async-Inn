using System;
using System.Collections.Generic;

namespace Inn_Management_System.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Layout { get; set; }

        public List<RoomAmenity> RoomAmenitys { get; set; }
        public List<HotelRoom> HotelRooms { get; set; }

        public static implicit operator Room(Amenity v)
        {
            throw new NotImplementedException();
        }
    }
}
