using AutoMapper;
using Comment_Service.Data;
using Comment_Service.Models;
using Comment_Service.Services.IServices;

namespace Comment_Service.Services
{
    public class CommentServices : IComment
    {
        //get context
        private readonly CommentDBContext _context;
       
        public CommentServices(CommentDBContext context)
        {
        _context = context;
        }
        public async Task<string> CreateComment(Comment comment)
        {
            try
            {
                await _context.comments.AddAsync(comment);
                _context.SaveChanges();
                return "comment posted";
            }
            catch (Exception ex)
            {
                return ($"{ex.InnerException}");
            }
        }

        public async Task<string> DeleteComment(Comment comment)
        {
            try
            {
                _context.comments.Remove(comment);
                await _context.SaveChangesAsync();
                return "Comment removed";

            }
            catch (Exception ex)
            {
                return $"Something went wrong {ex.InnerException}";

            }
        }

        public async Task<Comment> GetCommentById(Guid commentId)
        {
            Comment post = await _context.FindAsync<Comment>(commentId);
            return post;
        }

        public async Task<List<Comment>> GetComments(Guid postId)
        {
            List<Comment> comments = _context.comments.Where(x=>x.postId == postId).ToList();
            return comments;

        }

        public async Task<string> UpdateComment(Comment comment)
        {
            try
            {
                _context.comments.Update(comment);
                await _context.SaveChangesAsync();
                return "updated successfully";
            }
            catch (Exception ex)
            {
                return ($"Something went very wrong {ex.InnerException}");
            }
        }
    }
}
