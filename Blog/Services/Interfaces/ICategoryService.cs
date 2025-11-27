using Blog.API.Models.DTOs;
namespace Blog.API.Services.Interfaces
{
    public interface ICategoryService
    {

        Task<List<CategoryResponseDTO>> GetAllCategoriesAsync();

        Task CreateCategoryAsync(CategoryRequestDTO category);

        Task<CategoryResponseDTO> GetCategoriaByIDAsync(int id);

        Task UpdateCategoryByIDAsync(CategoryRequestDTO category, int id);

        Task DeleteCategoryByIDAsync(int id);
    }
}
