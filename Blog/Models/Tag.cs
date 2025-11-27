using System.Text.Json.Serialization;

namespace Blog.API.Models
{
    public class Tag
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Slug { get; private set; }


        [JsonConstructor]
        public Tag(string name, string slug)
        {
            Name = name;
            Slug = slug;
        }
    }
}
