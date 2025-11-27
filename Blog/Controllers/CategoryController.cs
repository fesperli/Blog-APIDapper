using Blog.API.Models.DTOs;
using Blog.API.Services;
using Blog.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("Online");
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<List<CategoryResponseDTO>>> GetAllCategoriesAsync()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);

        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateCategory(CategoryRequestDTO category)
        {
            await _categoryService.CreateCategoryAsync(category);

            return Created();
        }

        [HttpGet("GetByID")]
        public async Task<ActionResult<CategoryResponseDTO>> GetCategoriaByIDAsync(int id)
        {
            var category = await _categoryService.GetCategoriaByIDAsync(id);
            return Ok(category);
        }

        [HttpPut("UpdateByID")]
        public async Task<ActionResult> UpdateCategoryByIDAsync(CategoryRequestDTO category, int id)
        {
            var categoryFound = await _categoryService.GetCategoriaByIDAsync(id);

            if(categoryFound is null)
            {
                return NotFound();
            }

            await _categoryService.UpdateCategoryByIDAsync(category, id);
            return Ok();
        }

        [HttpDelete("DeleteByID")]
        public async Task<ActionResult> DeleteCategoryByIDAsync(int id)
        {
            var categoryFound = await _categoryService.GetCategoriaByIDAsync(id);

            if (categoryFound is null)
            {
                return NotFound();
            }

            await _categoryService.DeleteCategoryByIDAsync(id);
            return Ok();
        }


    }
}
