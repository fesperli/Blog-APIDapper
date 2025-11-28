using Blog.API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.Interfaces
{
    public interface ITagController
    {
        ActionResult HeartBeat();

        Task<ActionResult<List<TagResponseDTO>>> GetAllTagsAsync();

        Task<ActionResult> CreateTagAsync(TagRequestDTO tag);

        Task<ActionResult<TagResponseDTO>> GetTagsByIDAsync(int id);

        Task<ActionResult> UpdateTagByID(TagRequestDTO tag, int id);

        Task<ActionResult> DeleteRoleByIDAsync(int id);
    }
}
