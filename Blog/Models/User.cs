using System.Text.Json.Serialization;

namespace Blog.API.Models
{
    public class User
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string PasswordHash { get; private set; }

        public string Bio { get; private set; }

        public string Image { get; private set; }

        public string Slug { get; private set; }
        public List<Role> Roles { get; set; }

        [JsonConstructor]
        public User(string name, string email, string passwordHash, string bio, string image, string slug)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            Bio = bio;
            Image = image;
            Slug = slug;
        }
        [JsonConstructor]
        public User (int id, string name, string email, string passwordHash, string bio, string image, string slug)
        {
            Id = id;
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            Bio = bio;
            Image = image;
            Slug = slug;
        }
        public void AddRole(Role role)
        {
            Roles.Add(role);
        }
    }
}
