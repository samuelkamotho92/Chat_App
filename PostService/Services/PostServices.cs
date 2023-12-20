using PostService.Data;
using PostService.Dtos;
using PostService.Models;
using PostService.Services.IService;

namespace PostService.Services
{
    public class PostServices : IPost
    {
        private readonly PostDbContext _postDbContext;
        public PostServices(PostDbContext postDbContext)
        {
            _postDbContext = postDbContext;
            
        }
        public async Task<Post> CreatePost(PostDto post)
        {
         
          var postVal = await _postDbContext.AddAsync(post);


        
               
        }

        public Task<string> DeletePosts(Guid postId)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetpostbyId(Guid postId)
        {
            throw new NotImplementedException();
        }

        public Task GetPosts()
        {
            throw new NotImplementedException();
        }

        public Task<Post> UpdatePost(Guid postId)
        {
            throw new NotImplementedException();
        }
    }
}
