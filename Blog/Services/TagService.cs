using Azure;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories;
using Blog.API.Repositories.Interfaces;
using Blog.API.Services.Interfaces;
namespace Blog.API.Services
{
    public class TagService : ITagService
    {
        private ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<List<TagResponseDTO>> GetAllTagsAsync()
        {
            return await _tagRepository.GetAllTagsAsync();
        }

        public async Task CreateTagAsync(TagRequestDTO tag)
        {
            var newTag = new Tag(tag.Name, tag.Name.ToLower().Replace(" ", "-"));
            await _tagRepository.CreateTagAsync(newTag);
        }

        public async Task<TagResponseDTO> GetTagByIDAsync(int id)
        {
            return await _tagRepository.GetTagByIDAsync(id);
        }

        public async Task UpdateTagByIDAsync(TagRequestDTO tag, int id)
        {
            var newTag = new Tag(tag.Name, tag.Name.ToLower().Replace(" ", "-"));
            await _tagRepository.UpdateTagByIDAsync(newTag,id);
        }

        public async Task DeleteTagByIDAsync(int id)
        {
            await _tagRepository.DeleteTagByIDAsync(id);
        }
    }
}
