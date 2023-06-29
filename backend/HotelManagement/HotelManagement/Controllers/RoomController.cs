using AutoMapper;
using Azure.Core;
using HotelManagement.DTOs;
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
        private readonly IMapper _mapper;
        public RoomController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Room>>> GetAllRooms()
        {
            var rooms = await _roomService.GetAllRoomsAsync();
            return Ok(rooms);
        }

        [HttpGet("{roomNumber:int}")]
        public async Task<ActionResult<Room>> GetRoomByNumber(int roomNumber)
        {
            var room = await _roomService.GetRoomByNumberAsync(roomNumber);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        [HttpPost] 
        public IActionResult CreateRoom(RoomDTO roomDTO)
        {
            var room = _mapper.Map<Room>(roomDTO);
            _roomService.CreateRoom(room);
            return Ok(room);
        }

        [HttpPut("{roomNumber:int}")]
        public async Task<IActionResult> UpdateRoom(int roomNumber, [FromBody] Room room)
        {
            var updated = await _roomService.UpdateRoomAsync(room);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{roomNumber:int}")]
        public async Task<IActionResult> DeleteRoom(int roomNumber)
        {
            var deleted = await _roomService.DeleteRoomAsync(roomNumber);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

