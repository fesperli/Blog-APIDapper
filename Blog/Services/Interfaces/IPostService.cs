using Blog.API.Models.DTOs;

namespace Blog.API.Services.Interfaces
{
    public interface IPostService
    {
        Task<List<PostResponseDTO>> GetAllPostsAsync();
        Task<PostResponseDTO> GetPostByIdAsync(int id);
        Task CreatePostAsync(PostRequestDTO dto);
        Task UpdatePostAsync(int id, PostRequestDTO dto);
        Task DeletePostAsync(int id);
    }
}
