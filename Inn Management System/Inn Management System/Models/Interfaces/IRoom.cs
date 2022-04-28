using Inn_Management_System.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inn_Management_System.Models.Interfaces
{
    public interface IRoom
    {
      
        Task<RoomsDto> CreateRoom(RoomsDto room);
        Task<RoomsDto> GetRoom(int Id);
        Task<List<RoomsDto>> GetRooms();
        Task<RoomsDto> UpdateRoom(int ID, RoomsDto room);
        Task DeleteRoom(int Id);
        Task AddAmenityToRoom(int roomId, int amenityId);
        Task RemoveAmentityFromRoom(int roomId, int amenityId);

    }
}
