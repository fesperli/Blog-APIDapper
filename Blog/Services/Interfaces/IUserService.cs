using Blog.API.Models;
using Blog.API.Models.DTOs;

namespace Blog.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponseDTO>> GetAllUsersAsync();

        Task CreateUserAsync(UserRequestDTO user);
    }
}
