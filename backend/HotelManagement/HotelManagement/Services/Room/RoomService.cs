using HotelManagement.Data;
using HotelManagement.Models;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Services
{
    public class RoomService : IRoomService
    {
        private readonly HotelManagementContext _context;

        public RoomService(HotelManagementContext context)
        {
            _context = context;
        }

        public async Task<List<Room>> GetAllRoomsAsync()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room?> GetRoomByNumberAsync(int roomNumber)
        {
            return await _context.Rooms.FindAsync(roomNumber);
        }

        public Room CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
            return room;
        }

        public async Task<bool> UpdateRoomAsync(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            int affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<bool> DeleteRoomAsync(int roomNumber)
        {
            var room = await _context.Rooms.FindAsync(roomNumber);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                int affectedRows = await _context.SaveChangesAsync();
                return affectedRows > 0;
            }
            return false;
        }
    }
}
