using HotelManagement.Data;
using HotelManagement.DTOs;
using HotelManagement.Models;
using Microsoft.AspNetCore.Authentication;

namespace HotelManagement.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HotelManagementContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationService(HotelManagementContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> RegisterAsync(RegisterDTO registerDTO)
        {
            // Check if username already exists
            if (await _context.Users.AnyAsync(u => u.Username == registerDTO.Username))
            {
                return false; // Username already taken
            }

            // Create a new User entity
            var user = new User
            {
                Username = registerDTO.Username,
                Password = HashPassword(registerDTO.Password),
                HotelName = registerDTO.HotelName
            };

            // Add the user to the database
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return true; // Registration successful
        }

        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            // Find the user by username
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == username);

            // Check if user exists and the password is correct
            if (user != null && VerifyPassword(password, user.Password))
            {
                return user; // Authentication successful
            }

            return null; // Invalid credentials
        }

        // Helper method to hash the password
        private string HashPassword(string password)
        {
            // Use a suitable password hashing algorithm (e.g., bcrypt, Argon2, etc.)
            // Hash the password and return the hashed value
            return /* Your password hashing logic */;
        }

        // Helper method to verify the password
        private bool VerifyPassword(string password, string hashedPassword)
        {
            // Use the same password hashing algorithm used during registration
            // Compare the hashed password with the provided password and return the result
            return /* Your password verification logic */;
        }
        public async Task LogoutAsync(string username)
        {
            // Clear the authentication token or session for the user
            _httpContextAccessor.HttpContext.SignOutAsync();

            // You can perform additional cleanup or logging out logic here if needed

            // Example: Log the user out of your application-specific session
            // Your implementation may vary depending on your authentication mechanism
            await YourSessionManager.LogoutAsync(username);
        }
    }

}
