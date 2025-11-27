using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories;
using Blog.API.Repositories.Interfaces;
using Blog.API.Services.Interfaces;

namespace Blog.API.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserResponseDTO>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task CreateUserAsync(UserRequestDTO user)
        {
            var newUser = new User(user.Name, user.Email, user.PasswordHash, user.Bio, user.Image, user.Name.ToLower().Replace(" ", "-"));
            await _userRepository.CreateUserAsync(newUser);

        }
        public async Task<UserResponseDTO> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIDAsync(id);
        }
        public async Task UpdateUserByIdAsync(UserRequestDTO user, int id)
        {
            var updatedUser = new User(user.Name, user.Email, user.PasswordHash, user.Bio, user.Image, user.Name.ToLower().Replace(" ", "-"));
            await _userRepository.UpdateUserByIDAsync(updatedUser, id);
        }
        public async Task DeleteUserByIdAsync(int id)
        {
            await _userRepository.DeleteUserByIDAsync(id);
        }
    }
}
