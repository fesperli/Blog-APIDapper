using Blog.API.Models;
using Blog.API.Models.DTOs;

namespace Blog.API.Services.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleResponseDTO>> GetAllRolesAsync();

        Task CreateRoleAsync(RoleRequestDTO role);

        Task<RoleResponseDTO> GetRoleByIDAsync(int id);

        Task UpdateRoleByIDAsync(RoleRequestDTO role, int id);

        Task DeleteRoleByIDAsync(int id);
    }
}
