using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories.Interfaces;
using Blog.API.Services.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace Blog.API.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SqlConnection _connection;

        public PostRepository(ConnectionDB connection)
        {
            _connection = connection.GetConnection();
        }

        public async Task<List<PostResponseDTO>> GetAllAsync()
        {
            var sql = @"
        SELECT 
            -- 1. Bloco do POST (PostResponseDTO)
            P.Id, P.Title, 
            P.Summary, P.Body, 
            P.Slug, P.CreateDate, 
            P.LastUpdateDate,
            U.Name AS AuthorName,     
            C.Name AS CategoryName,   
            T.Id, 
            T.Name, 
            T.Slug 
        FROM Post P
        LEFT JOIN [User] U ON P.AuthorId = U.Id
        LEFT JOIN Category C ON P.CategoryId = C.Id
        LEFT JOIN PostTag PT ON P.Id = PT.PostId
        LEFT JOIN Tag T ON PT.TagId = T.Id";

            var postDictionary = new Dictionary<int, PostResponseDTO>();

            await _connection.QueryAsync<PostResponseDTO, TagResponseDTO, PostResponseDTO>(
                sql,
                (post, tag) =>
                {
                    if (!postDictionary.TryGetValue(post.Id, out var postEntry))
                    {
                        postEntry = post;
                        postEntry.Tags = new List<TagResponseDTO>();
                        postDictionary.Add(postEntry.Id, postEntry);
                    }

                    if (tag != null)
                    {
                        postEntry.Tags.Add(tag);
                    }
                    return postEntry;
                },
                splitOn: "Id" // O Dapper vai identificar que a Tag começa quando encontrar a coluna "Id" repetida (a do T.Id)
            );

            return postDictionary.Values.ToList();
        }

        public async Task<PostResponseDTO> GetByIdAsync(int id)
        {

            var allPosts = await GetAllAsync();
            return allPosts.FirstOrDefault(p => p.Id == id);
        }

        public async Task CreatePostAsync(Post post, List<int> tagIds)
        {
            if (_connection.State != ConnectionState.Open) await _connection.OpenAsync();

            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    var sqlPost = @"
                        INSERT INTO Post (CategoryId, AuthorId, Title, Summary, Body, Slug, CreateDate, LastUpdateDate)
                        VALUES (@CategoryId, @AuthorId, @Title, @Summary, @Body, @Slug, @CreateDate, @LastUpdateDate);
                        SELECT CAST(SCOPE_IDENTITY() as int)";

                    var newId = await _connection.QuerySingleAsync<int>(sqlPost, post, transaction);

                    if (tagIds != null && tagIds.Any())
                    {
                        var sqlTags = "INSERT INTO PostTag (PostId, TagId) VALUES (@PostId, @TagId)";
                        foreach (var tagId in tagIds)
                        {
                            await _connection.ExecuteAsync(sqlTags, new { PostId = newId, TagId = tagId }, transaction);
                        }
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public async Task UpdatePostAsync(Post post)
        {
            var sql = @"
                UPDATE Post 
                SET Title = @Title, Summary = @Summary, Body = @Body, 
                    Slug = @Slug, CategoryId = @CategoryId, LastUpdateDate = @LastUpdateDate
                WHERE Id = @Id";

            await _connection.ExecuteAsync(sql, post);
        }

        public async Task DeletePostAsync(int id)
        {
            var sql = @"
                DELETE FROM PostTag WHERE PostId = @Id;
                DELETE FROM Post WHERE Id = @Id;";

            await _connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}

