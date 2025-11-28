using Blog.API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.Interfaces
{
    public interface IUserController
    {
        ActionResult HeartBeat();

        Task<ActionResult<List<UserResponseDTO>>> GetAllUsersAsync();

        Task<ActionResult> CreateUserAsync(UserRequestDTO user);

        Task<ActionResult<UserResponseDTO>> GetUserByIDAsync(int id);

        Task<ActionResult> UpdateUserByIDAsync(UserRequestDTO user, int id);

        Task<ActionResult> DeleteUserByIDAsync(int id);

        Task<ActionResult<List<UserRolesResponseDTO>>> GetUsersRoles();
    }
}
