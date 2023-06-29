using HotelManagement.Models;

public interface IRoomService
{
    Task<List<Room>> GetAllRoomsAsync();
    Task<Room?> GetRoomByNumberAsync(int roomNumber);
    Task<List<Room>> GetRoomsByNumbersAsync(List<int> roomNumbers);
    Room CreateRoom(Room room);
    Task<bool> UpdateRoomAsync(Room room);
    Task<bool> DeleteRoomAsync(int roomNumber);
}

