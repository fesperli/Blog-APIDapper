using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SqlConnection _connection;

        public CategoryRepository(ConnectionDB connection)
        {
            _connection = connection.GetConnection();
        }

        public async Task<List<CategoryResponseDTO>> GetAllCategoriesAsync()
        {
            var sql = "SELECT Name,Slug FROM Category";
            return (await _connection.QueryAsync<CategoryResponseDTO>(sql)).ToList();       
        }

        public async Task CreateCategoryAsync(Category category)
        {
            var sql = "INSERT INTO Category (Name,Slug) VALUES (@Name,@Slug)";
            await _connection.ExecuteAsync(sql, new { category.Name, category.Slug });
        }

        public async Task<CategoryResponseDTO> GetCategoriaByIDAsync(int id)
        {
            var sql = "SELECT Name,Slug FROM Category WHERE Id = @CategoryID";
            return (await _connection.QueryFirstOrDefaultAsync<CategoryResponseDTO>(sql, new { CategoryID = id }));
        }

        public async Task UpdateCategoryByIDAsync(Category category, int id)
        {
            var sql = "UPDATE Category SET Name = @Name,Slug = @Slug WHERE Id = @CategoryID";
            await _connection.ExecuteAsync(sql, new { category.Name, category.Slug, CategoryID = id });
        }

        public async Task DeleteCategoryByIDAsync(int id)
        {
            var sql = "DELETE FROM Category WHERE Id = @CategoryID";
            await _connection.ExecuteAsync(sql, new { CategoryID = id });
        }

    }
}
