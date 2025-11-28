namespace Blog.API.Models.DTOs
{
    public class PostResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; } 
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public List<TagResponseDTO> Tags { get; set; } = new List<TagResponseDTO>();
    }
}
