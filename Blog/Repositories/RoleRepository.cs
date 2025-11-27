using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly SqlConnection _connection;

        public RoleRepository(ConnectionDB connection)
        {
            _connection = connection.GetConnection();
        }

        public async Task<List<RoleResponseDTO>> GetAllRolesAsync()
        {
            var sql = "SELECT Name,Slug FROM Role";
            return (await _connection.QueryAsync<RoleResponseDTO>(sql)).ToList();
        }

        public async Task CreateRoleAsync(Role role)
        {
            var sql = "INSERT INTO Role(Name,Slug) VALUES (@Name,@Slug)";
            await _connection.ExecuteAsync(sql, new { role.Name, role.Slug });
        }

        public async Task<RoleResponseDTO> GetRoleByIDAsync(int id)
        {
            var sql = "SELECT Name,Slug FROM Role WHERE Id = @RoleID";
            return (await _connection.QueryFirstOrDefaultAsync<RoleResponseDTO>(sql, new { RoleID = id }));
        }

        public async Task UpdateRoleByIDAsync(Role role, int id)
        {
            var sql = "UPDATE Role SET Name = @Name,Slug = @Slug WHERE Id = @RoleID";
            await _connection.ExecuteAsync(sql, new { role.Name, role.Slug, RoleID = id });
        }

        public async Task DeleteRoleByIDAsync(int id)
        {
            var sql = "DELETE FROM Role WHERE Id = @RoleID";
            await _connection.ExecuteAsync(sql, new { RoleID = id });
        }
    }
}
