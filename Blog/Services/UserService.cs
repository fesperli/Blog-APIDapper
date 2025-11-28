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
            return await _userRepository.GetUserByIdDAsync(id);
        }
        public async Task UpdateUserByIdAsync(UserRequestDTO user, int id)
        {
            var updatedUser = new User(user.Name, user.Email, user.PasswordHash, user.Bio, user.Image, user.Name.ToLower().Replace(" ", "-"));
            await _userRepository.UpdateUserByIdAsync(updatedUser, id);
        }
        public async Task DeleteUserByIdAsync(int id)
        {
            await _userRepository.DeleteUserByIdAsync(id);
        }
        public async Task<List<UserRolesResponseDTO>> GetAllUsersRoles()
        {
            var user = await _userRepository.GetAllUserRoles();

            var dtos = user.Select(user => new UserRolesResponseDTO
            {
                Name = user.Name,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                Bio = user.Bio,
                Image = user.Image,
                Slug = user.Slug,
                Roles = user.Roles.Select(r => new RoleResponseDTO
                {
                    Name = r.Name,
                    Slug = r.Slug
                }).ToList()
            }).ToList();

            return dtos;
        }

        public async Task<UserRolesResponseDTO> GetUserRolesId(int id)
        {
            var user = await _userRepository.GetUserRolesId(id);

            if (user == null)
            {
                return null;
            }

            var dto = new UserRolesResponseDTO
            {
                Name = user.Name,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                Bio = user.Bio,
                Image = user.Image,
                Slug = user.Slug,

                Roles = user.Roles?.Select(role => new RoleResponseDTO
                {
                    Name = role.Name,
                    Slug = role.Slug
                }).ToList(),
            };
            return dto;
        }
    }
}

