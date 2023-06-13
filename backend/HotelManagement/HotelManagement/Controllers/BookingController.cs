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
        [FromBody] Customer customer,
        [FromBody] DateTime bookingStart,
        [FromBody] DateTime bookingEnd,
        [FromBody] int? thirdPartyId,
        [FromBody] List<int> roomNumbers)
        {
            // Check if the customer already exists
            var existingCustomer = await _customerService.GetCustomerByIdAsync(customer.CustomerId);
            if (existingCustomer == null)
            {               
                _customerService.CreateCustomer(customer);
            }
            else
            {
                // Customer already exists, update the customer object
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Email = customer.Email;
                existingCustomer.Phone = customer.Phone;
                existingCustomer.Address = customer.Address;
                await _customerService.UpdateCustomerAsync(existingCustomer);
            }

            var booking = new Booking
            {
                BookingPlaced = DateTime.Now,
                BookingStart = bookingStart,
                BookingEnd = bookingEnd,
                ThirdPartyId = thirdPartyId,
                CustomerId = customer.CustomerId,
                Customer = customer
            };
            // Create booking details
            var bookingDetails = new List<BookingDetail>();
            foreach (var roomNumber in roomNumbers)
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
