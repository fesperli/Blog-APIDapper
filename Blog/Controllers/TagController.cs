using Blog.API.Models.DTOs;
using Blog.API.Services;
using Blog.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {

        private ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("Online");
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<TagResponseDTO>>> GetAllTagsAsync()
        {
            return Ok(await _tagService.GetAllTagsAsync());
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateTagAsync(TagRequestDTO tag)
        {
            await _tagService.CreateTagAsync(tag);

            return Created();
        }

        [HttpGet("GetByID")]
        public async Task<ActionResult<TagResponseDTO>> GetTagsByIDAsync(int id)
        {
            return Ok(await _tagService.GetTagByIDAsync(id));
        }

        [HttpPut("UpdateByID")]
        public async Task<ActionResult> UpdateTagByID(TagRequestDTO tag, int id)
        {
            var tagFound = await _tagService.GetTagByIDAsync(id);

            if (tagFound is null)
            {
                return NotFound();
            }

            await _tagService.UpdateTagByIDAsync(tag, id);
            return Ok();
        }

        [HttpDelete("DeleteByID")]
        public async Task<ActionResult> DeleteRoleByIDAsync(int id)
        {
            var tagFound = await _tagService.GetTagByIDAsync(id);

            if (tagFound is null)
            {
                return NotFound();
            }

            await _tagService.DeleteTagByIDAsync(id);
            return Ok();
        }
    }
}
