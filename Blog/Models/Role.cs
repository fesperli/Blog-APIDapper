using System.Text.Json.Serialization;

namespace Blog.API.Models
{
    public class Role
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Slug { get; private set; }
        public List<User> Users { get; set; }


        [JsonConstructor]
        public Role(string name, string slug)
        {
            Name = name;
            Slug = slug;
        }
        [JsonConstructor]
        public Role(int id, string name, string slug) 
        {
            Id = id;
            Name = name;
            Users = new List<User>();
        }
    }
}
