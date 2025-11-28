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

        Task<List<UserRolesResponseDTO>> GetAllUsersRoles();

        Task<UserRolesResponseDTO> GetUserRolesId(int id);

        Task<bool> CreateUserRolesAsync(int userId, int roleId);


    }
}
