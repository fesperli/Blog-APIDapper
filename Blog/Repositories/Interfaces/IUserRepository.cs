using Blog.API.Models;
using Blog.API.Models.DTOs;

namespace Blog.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserResponseDTO>> GetAllUsersAsync();

        Task CreateUserAsync(User user);
        Task<UserResponseDTO> GetUserByIDAsync(int id);
        Task UpdateUserByIDAsync(User user, int id);
        Task DeleteUserByIDAsync(int id);

    }
}
