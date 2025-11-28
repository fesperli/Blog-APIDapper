namespace Blog.API.Models.DTOs
{
    public class PostRequestDTO
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }

        public List<int> TagsIds { get; set; } = new List<int>();
    }
}
