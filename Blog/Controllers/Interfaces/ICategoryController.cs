using Blog.API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.Interfaces
{
    public interface ICategoryController
    {
        ActionResult HeartBeat();
        Task<ActionResult<List<CategoryResponseDTO>>> GetAllCategoriesAsync();
        Task<ActionResult> CreateCategory(CategoryRequestDTO category);
        Task<ActionResult<CategoryResponseDTO>> GetCategoriaByIDAsync(int id);
        Task<ActionResult> UpdateCategoryByIDAsync(CategoryRequestDTO category, int id);
        Task<ActionResult> DeleteCategoryByIDAsync(int id);
    }
}
