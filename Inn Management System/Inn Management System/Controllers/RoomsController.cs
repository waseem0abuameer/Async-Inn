using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inn_Management_System.Data;
using Inn_Management_System.Models;
using Inn_Management_System.Models.Servieces;
using Inn_Management_System.Models.Interfaces;
using Inn_Management_System.Models.DTO;

namespace Inn_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoom _room;

        public RoomsController(IRoom room)
        {
            _room = room;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomsDto>>> GetRooms()
        {
            return Ok(await _room.GetRooms());
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomsDto>> GetRoom(int id)
        {
            var room = await _room.GetRoom(id);

            return Ok(room);
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, RoomsDto room)
        {
            if (id != room.ID)
            {
                return BadRequest();
            }

            var updatedRoom = await _room.UpdateRoom(id, room);
            return Ok(updatedRoom);
        }

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(RoomsDto room)
        {
            await _room.CreateRoom(room);
            return CreatedAtAction("GetRoom", new { id = room.ID }, room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _room.DeleteRoom(id);
            return NoContent();


        }

        //Adds an amenity to a room
        [HttpPost]
        [Route("{roomId}/Amenity/{amenityId}")]
        public async Task<IActionResult> AddAmenityToRoom(int roomId, int amenityId)
        {
            await _room.AddAmenityToRoom(roomId, amenityId);
            return NoContent();
        }
        //removes an amenity from a room
        [HttpDelete]
        [Route("{roomId}/{amenityId}")]
        public async Task<IActionResult> DeleteAmenityFromRoom(int roomId, int amenityId)
        {
            await _room.RemoveAmentityFromRoom(roomId, amenityId);
            return NoContent();
        }
    }
}
