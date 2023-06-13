using HotelManagement.Models;
using HotelManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.Controllers
{
    [ApiController]
    [Route("/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] Customer customer)
        {
            var createdCustomer = await _customerService.CreateCustomer(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.CustomerId }, createdCustomer);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Customer>> UpdateCustomer(int id, [FromBody] Customer customer)
        {
            if (id != customer.CustomerId)
                return BadRequest();

            var updatedCustomer = await _customerService.UpdateCustomer(customer);
            return Ok(updatedCustomer);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            var deletedCustomer = await _customerService.DeleteCustomer(id);
            if (deletedCustomer == null)
                return NotFound();

            return Ok(deletedCustomer);
        }
    }
}
