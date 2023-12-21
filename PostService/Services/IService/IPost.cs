using PostService.Dtos;
using PostService.Models;

namespace PostService.Services.IService
{
    public interface IPost
    {
        Task<string> CreatePost(Post post);

        Task<List<Post>> GetPosts();

        Task<string> DeletePosts(Post post); 

        Task<Post> GetpostbyId(Guid postId);

        Task<string> UpdatePost(Post post);
    }
}
