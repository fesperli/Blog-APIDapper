using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlConnection _connection;

        public UserRepository(ConnectionDB connection)
        {
            _connection = connection.GetConnection();
        }

        public async Task<List<UserResponseDTO>> GetAllUsersAsync()
        {
            var sql = "SELECT Name,Email,PasswordHash,Bio,Image,Slug FROM [User]";
            return (await _connection.QueryAsync<UserResponseDTO>(sql)).ToList();
        }

        public async Task CreateUserAsync(User user)
        {
            var sql = "INSERT INTO [User] (Name,Email,PasswordHash,Bio,Image,Slug) VALUES (@Name,@Email,@PasswordHash,@Bio,@Image,@Slug)";
            await _connection.ExecuteAsync(sql, new { user.Name, user.Email, user.PasswordHash, user.Bio, user.Image, user.Slug });
        }

        public async Task<UserResponseDTO> GetUserByIDAsync(int id)
        {
            var sql = "SELECT Name,Email,PasswordHash,Bio,Image,Slug FROM [User] WHERE Id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<UserResponseDTO>(sql, new { Id = id });
        }
        public async Task UpdateUserByIDAsync(User user, int id)
        {
            var sql = "UPDATE [User] SET Name = @Name, Email = @Email, PasswordHash = @PasswordHash, Bio = @Bio, Image = @Image, Slug = @Slug WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new { user.Name, user.Email, user.PasswordHash, user.Bio, user.Image, user.Slug, Id = id });
        }
        public async Task DeleteUserByIDAsync(int id)
        {
            var sql = "DELETE FROM [User] WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
