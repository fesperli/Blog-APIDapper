using Blog.API.Models.DTOs;
using Blog.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class PostController : ControllerBase
        {
            private readonly IPostService _service;

            public PostController(IPostService service)
            {
                _service = service;
            }

            [HttpGet("GetAll")]
            public async Task<ActionResult<List<PostResponseDTO>>> Get()
            {
                var posts = await _service.GetAllPostsAsync();
                return Ok(posts);
            }

            [HttpGet("GetPostById{id}")]
            public async Task<ActionResult<PostResponseDTO>> GetById(int id)
            {
                var post = await _service.GetPostByIdAsync(id);
                if (post == null) return NotFound("Post não encontrado");
                return Ok(post);
            }

            [HttpPost("CreatePost")]
            public async Task<ActionResult> Create([FromBody] PostRequestDTO request)
            {
                try
                {
                    await _service.CreatePostAsync(request);
                    return Ok("fica na paz q deu bom bro");
                }
                catch (Exception ex)
                {
                    return BadRequest($"erro ao criar post: {ex.Message}");
                }
            }

            [HttpPut("UpdateById{id}")]
            public async Task<ActionResult> Update(int id, [FromBody] PostRequestDTO request)
            {
                await _service.UpdatePostAsync(id, request);
                return Ok("deu certo bro");
            }

            [HttpDelete("DeleteById")]
            public async Task<ActionResult> Delete(int id)
            {
                await _service.DeletePostAsync(id);
                return Ok("voce excluiu o proximo post a bombar");
            }
        }
}

