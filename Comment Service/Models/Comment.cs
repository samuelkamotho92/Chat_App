namespace Comment_Service.Models
{
    public class Comment
    {
        public Guid commentId { get; set; }

        public string content { get; set; }

        public Guid postId { get; set; }
        public DateTime created_on { get; set; }

        public DateTime updated_on { get; set; }

    }
}
