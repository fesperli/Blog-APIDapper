using Blog.API.Models.DTOs;

namespace Blog.API.Services.Interfaces
{
    public interface ITagService
    {
        Task<List<TagResponseDTO>> GetAllTagsAsync();

        Task CreateTagAsync(TagRequestDTO tag);

        Task<TagResponseDTO> GetTagByIDAsync(int id);

        Task UpdateTagByIDAsync(TagRequestDTO tag, int id);

        Task DeleteTagByIDAsync(int id);
    }
}
