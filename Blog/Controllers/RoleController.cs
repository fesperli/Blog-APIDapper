using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Services;
using Blog.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Blog.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("Online");
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<RoleResponseDTO>>> GetAllRolesAsync()
        {   
            return Ok(await _roleService.GetAllRolesAsync());
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateRoleAsync(RoleRequestDTO role)
        {
            await _roleService.CreateRoleAsync(role);

            return Created(); 
        }

        [HttpGet("GetByID")]
        public async Task<ActionResult<RoleResponseDTO>> GetRolesByIDAsync(int id)
        {
            return Ok(await _roleService.GetRoleByIDAsync(id));
        }

        [HttpPut("UpdateByID")]
        public async Task<ActionResult> UpdateRoleByID(RoleRequestDTO role, int id)
        {
            var roleFound = await _roleService.GetRoleByIDAsync(id);

            if (roleFound is null)
            {
                return NotFound();
            }

            await _roleService.UpdateRoleByIDAsync(role, id);
            return Ok();
        }

        [HttpDelete("DeleteByID")]
        public async Task<ActionResult> DeleteRoleByIDAsync(int id)
        {
            var roleFound = await _roleService.GetRoleByIDAsync(id);

            if (roleFound is null)
            {
                return NotFound();
            }

            await _roleService.DeleteRoleByIDAsync(id);
            return Ok();
        }
    }
}
