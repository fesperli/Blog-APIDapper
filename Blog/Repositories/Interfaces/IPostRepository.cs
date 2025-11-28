using Blog.API.Models;
using Blog.API.Models.DTOs;

namespace Blog.API.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Task<List<PostResponseDTO>> GetAllAsync();
        Task<PostResponseDTO> GetByIdAsync(int id);
        Task CreatePostAsync(Post post, List<int> tagIds);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(int id);
    }
}
