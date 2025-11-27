using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories;
using Blog.API.Repositories.Interfaces;
using Blog.API.Services.Interfaces;

namespace Blog.API.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryrepository)
        {
            _categoryRepository = categoryrepository;
        }

        public async Task<List<CategoryResponseDTO>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllCategoriesAsync();
        }

        public async Task CreateCategoryAsync(CategoryRequestDTO category)
        {
            var newCategory = new Category(category.Name, category.Name.ToLower().Replace(" ", "-"));
            await _categoryRepository.CreateCategoryAsync(newCategory);
        }

        public async Task<CategoryResponseDTO> GetCategoriaByIDAsync(int id)
        {
            return await _categoryRepository.GetCategoriaByIDAsync(id);
        }

        public async Task UpdateCategoryByIDAsync(CategoryRequestDTO category, int id)
        {
            var newCategory = new Category(category.Name, category.Name.ToLower().Replace(" ", "-"));
            await _categoryRepository.UpdateCategoryByIDAsync(newCategory,id);
        }

        public async Task DeleteCategoryByIDAsync(int id)
        {
            await _categoryRepository.DeleteCategoryByIDAsync(id);
        }

    }
}
