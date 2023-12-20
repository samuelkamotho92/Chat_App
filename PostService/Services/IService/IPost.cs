using PostService.Dtos;
using PostService.Models;

namespace PostService.Services.IService
{
    public interface IPost
    {
        Task<Post> CreatePost(PostDto post);

        Task GetPosts();

        Task<string> DeletePosts(Guid postId); 

        Task<Post> GetpostbyId(Guid postId);

        Task<Post> UpdatePost(Guid postId);
    }
}
