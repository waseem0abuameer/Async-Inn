using System;

namespace Inn_Management_System.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Layout { get; set; }

        public static implicit operator Room(Amenity v)
        {
            throw new NotImplementedException();
        }
    }
}
