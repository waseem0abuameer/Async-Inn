using Inn_Management_System.Data;
using Inn_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Inn_Management_System.Models.Servieces
{
    public class RoomRepository : IRoom
    {
        private readonly InnDbContext _context;

        public RoomRepository(InnDbContext context)
        {
            _context = context;
        }
     
        public async Task<Room> Create(Room room)
        {
            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return room;
        }
        public async Task<List<Room>> GetRooms()
        {
            //var rooms = await _context.Rooms.ToListAsync();
            //return rooms;
            return await _context.Rooms
        .Include(hr => hr.HotelRooms)
        .ThenInclude(h => h.Hotel)
        .ToListAsync();

        }
        public async Task<Room> GetRoom(int id)
        {
            //The system knows we have a primary key and will use it
            //Room room = await _context.Rooms.FindAsync(id);
            //return room;

           
                 return await _context.Rooms
                .Include(hr => hr.HotelRooms)
                .ThenInclude(h => h.Hotel)
                .FirstOrDefaultAsync(x => x.ID == id);


        }

        public async Task DeleteRoom(int id)
        {
            Room room = await GetRoom(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        public async Task<Room> UpdateRoom(int id, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }
    }
}