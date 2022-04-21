using Inn_Management_System.Data;
using Inn_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inn_Management_System.Models.Servieces
{
    public class HotelServieces:IHotel
    {
        private readonly InnDbContext _context;
        private HotelServieces context;

        public HotelServieces(InnDbContext context)
        {
            _context = context;
        }

        public HotelServieces(HotelServieces context)
        {
            this.context = context;
        }

        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotel;
        }

       
        public async Task<Hotel> GetHotel(int id)
        {
            Hotel hotel = await _context.Hotels.FindAsync(id);
            return hotel;
        }

        public async Task<List<Hotel>> GetHotels()
        {
            var hotels = await _context.Hotels.ToListAsync();
            return hotels;
        }

       
      

        public async Task<Hotel> UpdateHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
        public async Task DeleteHotel(int id)
        {
            Hotel hotel = await GetHotel(id);
           
                _context.Entry(hotel).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            


        }
    }
}
