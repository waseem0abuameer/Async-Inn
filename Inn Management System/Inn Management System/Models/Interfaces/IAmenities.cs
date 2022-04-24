using System.Collections.Generic;
using System.Threading.Tasks;
namespace Inn_Management_System.Models.Interfaces
{
    public interface IAmenities
    {

        Task<List<Amenity>> GetAmenitys();
        Task<Amenity> GetAmenity(int id);
        Task<Amenity> Create(Amenity amenity);
        Task DeleteAmenity(int id);
        Task<Amenity> UpdateAmenity(int id, Amenity amenity);
    }
}
