using System.Collections.Generic;

namespace Inn_Management_System.Models.DTO
{
    public class RoomsDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Layout { get; set; }
        public List<AmenityDTO> Amenities { get; set; }



    }
}
