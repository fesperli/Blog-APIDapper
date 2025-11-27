using System.Text.Json.Serialization;

namespace Blog.API.Models
{
    public class Role
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Slug { get; private set; }


        [JsonConstructor]
        public Role(string name, string slug)
        {
            Name = name;
            Slug = slug;
        }
    }
}
