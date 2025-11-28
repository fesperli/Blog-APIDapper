using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories.Interfaces;
using Blog.API.Services.Interfaces;

namespace Blog.API.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;

        public PostService(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PostResponseDTO>> GetAllPostsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PostResponseDTO> GetPostByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreatePostAsync(PostRequestDTO dto)
        {
            
            var post = new Post(
                dto.CategoryId,
                dto.AuthorId,
                dto.Title,
                dto.Summary,
                dto.Body
            );

            await _repository.CreatePostAsync(post, dto.TagsIds);
        }

        public async Task UpdatePostAsync(int id, PostRequestDTO dto)
        {
            var post = new Post(dto.CategoryId, 0, dto.Title, dto.Summary, dto.Body);

            typeof(Post).GetProperty("Id").SetValue(post, id);

            await _repository.UpdatePostAsync(post);
        }

        public async Task DeletePostAsync(int id)
        {
            await _repository.DeletePostAsync(id);
        }
    }
}
