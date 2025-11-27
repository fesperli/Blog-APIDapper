namespace Blog.API.Models.DTOs
{
    public class UserResponseDTO
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string Bio { get; set; }

        public string Image { get; set; }

        public string Slug { get; set; }
    }
}
