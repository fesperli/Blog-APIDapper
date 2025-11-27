using Blog.API.Models;
using Blog.API.Models.DTOs;
using System.Data.Common;

namespace Blog.API.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<CategoryResponseDTO>> GetAllCategoriesAsync();

        Task CreateCategoryAsync(Category category);

        Task<CategoryResponseDTO> GetCategoriaByIDAsync(int id);

        Task UpdateCategoryByIDAsync(Category category, int id);

        Task DeleteCategoryByIDAsync(int id);
    }
}
