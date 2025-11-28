using Blog.API.Models;
using Blog.API.Models.DTOs;

namespace Blog.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserResponseDTO>> GetAllUsersAsync();

        Task CreateUserAsync(User user);
        Task<UserResponseDTO> GetUserByIdDAsync(int id);
        Task UpdateUserByIdAsync(User user, int id);
        Task DeleteUserByIdAsync(int id);
        Task<List<User>> GetAllUserRoles();
        Task<User> GetUserRolesId(int id);
    }
}
