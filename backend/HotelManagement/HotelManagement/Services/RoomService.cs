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

        public async Task<List<Room>> GetAllRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room> GetRoomById(int id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(r => r.RoomId == id);
        }

        public async Task<Room> CreateRoom(Room room)
        {
            _context.Rooms.Add(room);            
            await _context.SaveChangesAsync();
            return _context.Rooms
                .Where(p => p.RoomId == room.RoomId)
                .FirstOrDefault() ?? throw new InvalidOperationException();
        }

        public async Task<Room> UpdateRoom(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<Room> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
                return null;

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return room;
        }
    }
}
