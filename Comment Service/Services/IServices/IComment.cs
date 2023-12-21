using Comment_Service.Dto;
using Comment_Service.Models;

namespace Comment_Service.Services.IServices
{
    public interface IComment
    {
        //Get a comment by post
        Task<List<Comment>> GetComments(Guid postid);


        Task<Comment> GetCommentById(Guid commentId);
        Task<string> CreateComment(Comment comment);
        Task<string> UpdateComment(Comment comment);

        Task<string> DeleteComment(Comment comment);
    }
}
