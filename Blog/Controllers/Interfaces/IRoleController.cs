using Blog.API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.Interfaces
{
    public interface IRoleController
    {
        ActionResult HeartBeat();

        Task<ActionResult<List<RoleResponseDTO>>> GetAllRolesAsync();

        Task<ActionResult> CreateRoleAsync(RoleRequestDTO role);

        Task<ActionResult<RoleResponseDTO>> GetRolesByIDAsync(int id);

        [HttpPut("UpdateByID/{id}")]
        Task<ActionResult> UpdateRoleByID(RoleRequestDTO role, int id);

        [HttpDelete("DeleteByID/{id}")]
        Task<ActionResult> DeleteRoleByIDAsync(int id);
    }
}
