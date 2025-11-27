using Blog.API.Models;
using Blog.API.Models.DTOs;

namespace Blog.API.Repositories.Interfaces
{
    public interface ITagRepository
    {
        Task<List<TagResponseDTO>> GetAllTagsAsync();

        Task CreateTagAsync(Tag tag);

        Task<TagResponseDTO> GetTagByIDAsync(int id);

        Task UpdateTagByIDAsync(Tag tag, int id);

        Task DeleteTagByIDAsync(int id);
    }
}
