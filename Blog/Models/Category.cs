using System.Text.Json.Serialization;

namespace Blog.API.Models
{
    public class Category
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Slug { get; private set; }


        [JsonConstructor]
        public Category(string name, string slug)
        {
            Name = name;
            Slug = slug;
        }
    }
}
