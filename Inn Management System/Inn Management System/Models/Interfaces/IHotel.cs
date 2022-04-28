﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inn_Management_System.Models.Interfaces
{
    public interface IHotel
    {
        Task<Hotel> Create(Hotel hotel);
        Task<List<Hotel>> GetHotels();
        Task<Hotel> GetHotel(int id);
        Task<Hotel> UpdateHotel(int id, Hotel hotel);
        Task DeleteHotel(int id);
         Task addRoomToHotel(int hotelid, int roomid);

    }
}
