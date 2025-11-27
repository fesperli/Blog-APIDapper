using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories;
using Blog.API.Repositories.Interfaces;
using Blog.API.Services.Interfaces;

namespace Blog.API.Services
{
    public class RoleService : IRoleService
    {

        private IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<List<RoleResponseDTO>> GetAllRolesAsync()
        {
            return await _roleRepository.GetAllRolesAsync();
        }

        public async Task CreateRoleAsync(RoleRequestDTO role)
        {
            var newRole = new Role(role.Name, role.Name.ToLower().Replace(" ", "-"));
            await _roleRepository.CreateRoleAsync(newRole);
        }

        public async Task<RoleResponseDTO> GetRoleByIDAsync(int id)
        {
            return await _roleRepository.GetRoleByIDAsync(id);
        }

        public async Task UpdateRoleByIDAsync(RoleRequestDTO role, int id)
        {
            var newRole = new Role(role.Name, role.Name.ToLower().Replace(" ", "-"));
            await _roleRepository.UpdateRoleByIDAsync(newRole, id);
        }

        public async Task DeleteRoleByIDAsync(int id)
        {
            await _roleRepository.DeleteRoleByIDAsync(id);
        }
    }
}
