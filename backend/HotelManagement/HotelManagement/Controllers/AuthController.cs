using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class AuthController : ControllerBase
    {/*
        private readonly IConfiguration _configuration;
        private readonly IUserService _service;
        private readonly IJwtService _jwtService;
        public AuthController(IConfiguration configuration, IUserService service, IJwtService jwtService)
        {
            _configuration = configuration;
            _service = service;
            _jwtService = jwtService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginDTO loginDto)
        {
            var user = await _service.Get(loginDto);
            if(user!= null) //&& verify*
            {
                var jwt = _jwtService.Generate(user);
                Response.Cookies.Append("jwt", jwt, new CookieOptions
                {
                    HttpOnly = true
                });
                return Ok(new { message = "success" });
            }
            return BadRequest(new { message = "Invalid Credentials" });
        }
    */}
}
