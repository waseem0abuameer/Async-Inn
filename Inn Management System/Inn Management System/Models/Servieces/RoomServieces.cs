using Inn_Management_System.Data;
using Inn_Management_System.Models.DTO;
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
     
        public async Task<RoomsDto> Create(RoomsDto room)
        {
            //_context.Entry(room).State = EntityState.Added;
            //await _context.SaveChangesAsync();
            //return room;
            Room newRoom = new Room
            {
                ID = room.ID,
                Name = room.Name,
                Layout = room.Layout
            };
            _context.Entry(newRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return room;
        }
        public async Task DeleteRoom(int Id)
        {
            Room room = await _context.Rooms.FindAsync(Id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<RoomsDto>> GetRooms()
        {
            //var rooms = await _context.Rooms.ToListAsync();
            //return rooms;
            //    return await _context.Rooms
            //.Include(hr => hr.HotelRooms)
            //.ThenInclude(h => h.Hotel)
            //.ToListAsync();
            return await _context.Rooms.Select(R => new RoomsDto
            {
                ID = R.ID,
                Name = R.Name,
                Layout = R.Layout,
                Amenities = R.RoomAmenitys
                    .Select(r => new AmenityDTO
                    {
                        ID = r.Amenity.ID,
                        Name = r.Amenity.Name
                    }).ToList()
            }).ToListAsync();

        }
        public async Task<RoomsDto> GetRoom(int id)
        {
            //The system knows we have a primary key and will use it
            //Room room = await _context.Rooms.FindAsync(id);
            //return room;


            // return await _context.Rooms
            //.Include(hr => hr.HotelRooms)
            //.ThenInclude(h => h.Hotel)
            //.FirstOrDefaultAsync(x => x.ID == id);


            return await _context.Rooms.Select(R => new RoomsDto
            {
                ID = R.ID,
                Name = R.Name,
                Layout = R.Layout,
                Amenities = R.RoomAmenitys
               .Select(r => new AmenityDTO
               {
                   ID = r.Amenity.ID,
                   Name = r.Amenity.Name
               }).ToList()
            }).FirstOrDefaultAsync(x => x.ID == id);


        }

        
        public async Task<RoomsDto> UpdateRoom(int id, RoomsDto room)
        {
            //_context.Entry(room).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
            //return room;
            Room UpdateRoom = new Room
            {
                ID = room.ID,
                Name = room.Name,
                Layout = room.Layout
            };
            _context.Entry(UpdateRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }
        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenity roomAmenity = new RoomAmenity()
            {
                RoomID = roomId,
                AmenityID = amenityId
            };

            _context.Entry(roomAmenity).State = EntityState.Added;

            await _context.SaveChangesAsync();
        }

        public async Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            var removeAmentity = _context.RoomAmenitys.FirstOrDefaultAsync(x => x.RoomID == roomId && x.AmenityID == amenityId);

            _context.Entry(removeAmentity).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }
    }
}