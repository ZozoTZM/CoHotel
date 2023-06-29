using Azure.Core;
using HotelManagement.Models;
using HotelManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelManagement.DTOs;
using AutoMapper;

namespace HotelManagement.Controllers
{
    [ApiController]
    [Route("/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly ICustomerService _customerService;
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public class CreateBookingRequest
        {
            public CustomerDTO Customer { get; set; }
            public BookingDTO Booking { get; set; }
        }

        public BookingController(IBookingService bookingService, ICustomerService customerService, IRoomService roomService, IMapper mapper)
        {
            _bookingService = bookingService;
            _customerService = customerService;
            _roomService = roomService;
            _mapper = mapper;
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
        public ActionResult<Booking> CreateBooking([FromBody] CreateBookingRequest request)
        {
            var customer = _mapper.Map<Customer>(request.Customer);
            var booking = _mapper.Map<Booking>(request.Booking);
            
            _customerService.CreateCustomer(customer);
            _bookingService.CreateBooking(booking);

            return Ok(booking);
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
