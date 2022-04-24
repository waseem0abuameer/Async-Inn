
using Inn_Management_System.Data;
using Inn_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Inn_Management_System.Models.Servieces
{
    public class AmenityServieces:IAmenities
    {

        private readonly InnDbContext _context;
        private AmenityServieces context;

        public AmenityServieces(InnDbContext context)
        {
            _context = context;
        }

        public AmenityServieces(AmenityServieces context)
        {
            this.context = context;
        }



        public async Task<Amenity> Create(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return amenity;
        }


        public async Task<Amenity> GetAmenity(int id)
        {
            Amenity amenity = await _context.Amenities.FindAsync(id);
            return amenity;
        }

        public async Task<List<Amenity>> GetAmenitys()
        {
            var amenity = await _context.Amenities.ToListAsync();
            return amenity;
        }




        public async Task<Amenity> UpdateAmenity(int id, Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }
        public async Task DeleteAmenity(int id)
        {
            Amenity amenity = await GetAmenity(id);

            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();



        }
    }
}
