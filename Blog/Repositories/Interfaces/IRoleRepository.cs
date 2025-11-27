using Blog.API.Models;
using Blog.API.Models.DTOs;
using System.Data.Common;

namespace Blog.API.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<RoleResponseDTO>> GetAllRolesAsync();

        Task CreateRoleAsync(Role role);

        Task<RoleResponseDTO> GetRoleByIDAsync(int id);

        Task UpdateRoleByIDAsync(Role role, int id);

        Task DeleteRoleByIDAsync(int id);
    }
}
