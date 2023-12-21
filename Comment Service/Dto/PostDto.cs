namespace Comment_Service.Dto
{
    public class PostDto
    {
        public Guid postid { get; set; }

        public string title { get; set; }

        public string content { get; set; }

        public string? postImage { get; set; }

        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }

        public Guid? userId { get; set; }
    }
}
