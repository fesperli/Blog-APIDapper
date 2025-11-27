using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace Blog.API.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly SqlConnection _connection;

        public TagRepository(ConnectionDB connection)
        {
            _connection = connection.GetConnection();
        }

        public async Task<List<TagResponseDTO>> GetAllTagsAsync()
        {
            var sql = "SELECT Name,Slug FROM Tag";
            return (await _connection.QueryAsync<TagResponseDTO>(sql)).ToList();
        }

        public async Task CreateTagAsync(Tag tag)
        {
            var sql = "INSERT INTO Tag (Name,Slug) VALUES (@Name,@Slug)";
            await _connection.ExecuteAsync(sql, new { tag.Name, tag.Slug });
        }

        public async Task<TagResponseDTO> GetTagByIDAsync(int id)
        {
            var sql = "SELECT Name,Slug FROM Tag WHERE Id = @TagID";
            return (await _connection.QueryFirstOrDefaultAsync<TagResponseDTO>(sql, new { TagID = id }));
        }

        public async Task UpdateTagByIDAsync(Tag tag, int id)
        {
            var sql = "UPDATE Tag SET Name = @Name,Slug = @Slug WHERE Id = @TagID";
            await _connection.ExecuteAsync(sql, new {tag.Name, tag.Slug,TagID = id});
        }

        public async Task DeleteTagByIDAsync(int id)
        {
            var sql = "DELETE FROM Tag WHERE Id = @TagID";
            await _connection.ExecuteAsync(sql, new { TagID = id });
        }

       

        

        
    }
}
