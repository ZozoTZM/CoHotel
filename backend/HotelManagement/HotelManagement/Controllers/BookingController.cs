using Azure.Core;
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
        private readonly ICustomerService _customerService;
        private readonly IBookingDetailService _bookingDetailService;
        private readonly IRoomService _roomService;

        public BookingController(IBookingService bookingService, ICustomerService customerService, IBookingDetailService bookingDetailService, IRoomService roomService)
        {
            _bookingService = bookingService;
            _customerService = customerService;
            _bookingDetailService = bookingDetailService;
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Booking>>> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookings();
            return Ok(bookings);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
                return NotFound();

            return Ok(booking);
        }
        [HttpGet("thirdparty/{id}")]
        public async Task<ActionResult<Booking>> GetBookingByThirdPartyId(int id)
        {

            var booking = await _bookingService.GetBookingByThirdPartyIdAsync(id);
            if (booking == null)
                return NotFound();

            return Ok(booking);
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking(
        [FromBody] BookingRequest bookingRequest)
        {
            
            var existingCustomer = await _customerService.GetCustomerByIdAsync(bookingRequest.Customer.CustomerId);
            if (existingCustomer == null)
            {               
                _customerService.CreateCustomer(bookingRequest.Customer);
            }
            else
            {
                // Customer already exists, update the customer object
                existingCustomer.FirstName = bookingRequest.Customer.FirstName;
                existingCustomer.LastName = bookingRequest.Customer.LastName;
                existingCustomer.Email = bookingRequest.Customer.Email;
                existingCustomer.Phone = bookingRequest.Customer.Phone;
                existingCustomer.Address = bookingRequest.Customer.Address;
                await _customerService.UpdateCustomerAsync(existingCustomer);
            }

            var booking = new Booking
            {
                BookingPlaced = DateTime.Now,
                BookingStart = bookingRequest.BookingStart,
                BookingEnd = bookingRequest.BookingEnd,
                ThirdPartyId = bookingRequest.ThirdPartyId,
                CustomerId = bookingRequest.Customer.CustomerId,
                
            };
            // Create booking details
            var bookingDetails = new List<BookingDetail>();
            foreach (var roomNumber in bookingRequest.RoomNumbers)
            {
                var room = await _roomService.GetRoomByNumberAsync(roomNumber);
                if (room == null)
                {
                    return BadRequest($"Room with ID {roomNumber} not found");
                }

                var bookingDetail = new BookingDetail
                {
                    Booking = booking,
                    Room = room
                };

                bookingDetails.Add(bookingDetail);
            }
            booking.BookingDetails = bookingDetails;

            var createdBooking = _bookingService.CreateBooking(booking);

            return CreatedAtAction(nameof(GetBookingById), new { id = createdBooking.BookingId }, createdBooking);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBooking(int id)
        {

            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
                return NotFound();


            var success = await _bookingService.DeleteBookingAsync(id);
            if (!success)
                return StatusCode(500, "Failed to delete the booking.");

            return NoContent();
        }
    }
}
