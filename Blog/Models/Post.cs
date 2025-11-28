namespace Blog.API.Models
{
    public class Post
    {
        public int Id { get; private set; }
        public int CategoryId { get; private set; }
        public int AuthorId { get; private set; }
        public string Title { get; private set; }
        public string Summary { get; private set; }
        public string Body { get; private set; }
        public string Slug { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }

        public Post () { }

        public Post(int categoryId, int authorId, string title, string summary, string body)
        {
            CategoryId = categoryId;
            AuthorId = authorId;
            Title = title;
            Summary = summary;
            Body = body;
            Slug = title.ToLower().Replace(" ", "-");
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
        }
    }
}
