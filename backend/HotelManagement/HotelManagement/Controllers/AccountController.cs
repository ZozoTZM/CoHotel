using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class AccountController : ControllerBase
    {
        [ApiController]




        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return Ok(); // Login successful
            }
            else
            {
                return BadRequest("Invalid login attempt."); // Login failed
            }
        }
    }
}
