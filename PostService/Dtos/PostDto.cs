namespace PostService.Dtos
{
    public class PostDto
    {

        public string title { get; set; }

        public string content { get; set; }

        public string? postImage { get; set; }

        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }
    }
}
