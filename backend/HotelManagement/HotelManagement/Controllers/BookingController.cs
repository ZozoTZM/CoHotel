using HotelManagement.Models;
using HotelManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.Controllers
{
    [ApiController]
    [Route("/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Booking>>> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookings();
            return Ok(bookings);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Booking>> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingById(id);
            if (booking == null)
                return NotFound();

            return Ok(booking);
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking([FromBody] Booking booking)
        {
            var createdBooking = await _bookingService.CreateBooking(booking);
            return CreatedAtAction(nameof(GetBookingById), new { id = createdBooking.BookingId }, createdBooking);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Booking>> UpdateBooking(int id, [FromBody] Booking booking)
        {
            if (id != booking.BookingId)
                return BadRequest();

            var updatedBooking = await _bookingService.UpdateBooking(booking);
            return Ok(updatedBooking);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Booking>> DeleteBooking(int id)
        {
            var deletedBooking = await _bookingService.DeleteBooking(id);
            if (deletedBooking == null)
                return NotFound();

            return Ok(deletedBooking);
        }
    }
}
