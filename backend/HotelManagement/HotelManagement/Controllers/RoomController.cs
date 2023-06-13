using Azure.Core;
using HotelManagement.Models;
using HotelManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.Controllers
{
    [ApiController]
    [Route("/rooms")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Room>>> GetAllRooms()
        {
            var rooms = await _roomService.GetAllRooms();
            return Ok(rooms);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Room>> GetRoomById(int id)
        {
            var room = await _roomService.GetRoomById(id);
            if (room == null)
                return NotFound();

            return Ok(room);
        }

        [HttpPost]
        public async Task<Room> CreateRoom([FromBody] Room room)
        {
            return await _roomService.CreateRoom(room);        
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Room>> UpdateRoom(int id, [FromBody] Room room)
        {
            if (id != room.RoomId)
                return BadRequest();

            var updatedRoom = await _roomService.UpdateRoom(room);
            return Ok(updatedRoom);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Room>> DeleteRoom(int id)
        {
            var deletedRoom = await _roomService.DeleteRoom(id);
            if (deletedRoom == null)
                return NotFound();

            return Ok(deletedRoom);
        }
    }
}
