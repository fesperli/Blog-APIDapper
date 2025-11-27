using Blog.API.Models;
using Blog.API.Models.DTOs;

namespace Blog.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponseDTO>> GetAllUsersAsync();

        Task CreateUserAsync(UserRequestDTO user);
        Task<UserResponseDTO> GetUserByIdAsync(int id);
        Task UpdateUserByIdAsync(UserRequestDTO user, int id);
        Task DeleteUserByIdAsync(int id);
    }
}
