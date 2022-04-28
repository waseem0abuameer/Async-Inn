using System.Collections.Generic;

namespace Inn_Management_System.Models
{
    public class Amenity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<RoomAmenity> RoomAmenitys { get; set; }
    }
}
