using API.Dtos;
using Domain.Entities;


namespace API.Services
{
    public interface IUserService
    {
        string GetMyName();
        Task<string> RegisterAsync(UserRegisterDto registerDto);
        Task<List<string>> GetTokenAsync(UserDto model);
        Task<string> LoginAsync(UserDto request);
        Task<string> AddRolAsync(UserRolDto model);
        Task<string> RefreshToken(string Username);
    }
}