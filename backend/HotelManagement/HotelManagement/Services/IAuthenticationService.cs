using HotelManagement.DTOs;
using HotelManagement.Models;

namespace HotelManagement.Services
{
    public interface IAuthenticationService
    {
        Task<bool> RegisterAsync(RegisterDTO registerDTO);
        Task<User?> AuthenticateAsync(string username, string password);
        Task LogoutAsync(string username);
    }


}
