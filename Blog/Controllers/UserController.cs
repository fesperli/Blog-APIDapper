using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Services;
using Blog.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("Online");
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<UserResponseDTO>>> GetAllUsersAsync()
        {
            return Ok(await _userService.GetAllUsersAsync());
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateUserAsync(UserRequestDTO user)
        {
            await _userService.CreateUserAsync(user);

            return Created();
        }
        [HttpGet("GetById")]
        public async Task<ActionResult<UserResponseDTO>> GetUserByIdAsync(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("UpdateById")]
        public async Task<ActionResult> UpdateUserByIdAsync(UserRequestDTO user, int id ){
            var userFound = await _userService.GetUserByIdAsync(id);
            if (userFound is null)
            {
                return NotFound();
            }
            await _userService.UpdateUserByIdAsync(user, id);
            return Ok();
        }
        [HttpDelete("DeleteById")]
        public async Task<ActionResult> DeleteUserByIdAsync(int id)
        {
            var userFound = await _userService.GetUserByIdAsync(id);
            if (userFound is null)
            {
                return NotFound();
            }
            await _userService.DeleteUserByIdAsync(id);
            return Ok();
        }
        [HttpGet("GetUsersRoles")]
        public async Task<ActionResult<List<UserRolesResponseDTO>>> GetUsersRoles()
        {
            var user = await _userService.GetAllUsersRoles();
            return Ok(user);
        }
        [HttpGet("GetUsersRolesID")]
        public async Task<ActionResult<UserRolesResponseDTO>> GetUserRolesID(int id)
        {
            var user = await _userService.GetUserRolesId(id);
            return Ok (user);
        }
    }
}
