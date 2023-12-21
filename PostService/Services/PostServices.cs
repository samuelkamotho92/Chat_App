using AutoMapper;
using Microsoft.Extensions.Hosting;
using PostService.Data;
using PostService.Dtos;
using PostService.Models;
using PostService.Services.IService;

namespace PostService.Services
{
    public class PostServices : IPost
    {
        private readonly PostDbContext _postDbContext;
        private readonly IMapper _mapper;
        public PostServices(PostDbContext postDbContext,IMapper mapper)
        {
            _postDbContext = postDbContext;
            _mapper = mapper;
            
        }
        public async Task<string> CreatePost(Post post)
        {
            try
            {             
               var postVal =   await _postDbContext.AddAsync(post);
                Console.WriteLine(postVal);
              _postDbContext.SaveChangesAsync();
                return "Successfully created post";
            }
            catch(Exception ex)
            {
                return ex.Message;

            }            
        }

        public async Task<string> DeletePosts(Post post)
        {
            try
            {
                _postDbContext.posts.Remove(post);
                await _postDbContext.SaveChangesAsync();
                return "Post removed";

            }catch(Exception ex)
            {
                return $"Something went wrong {ex.InnerException}";

            }
        }

        public async Task<Post> GetpostbyId(Guid postId)
        {
            Post post = await  _postDbContext.FindAsync<Post>(postId);
            return post;
        }

        public async Task<List<Post>> GetPosts()
        {
         
            List<Post> posts= _postDbContext.posts.ToList();         
             return posts;
         
        }

        public async Task<string> UpdatePost(Post post)
        {
            try
            {
                _postDbContext.posts.Update(post);
                await _postDbContext.SaveChangesAsync();
                return "updated successfully";
            }
            catch (Exception ex)
            {
                return ($"Something went very wrong {ex.InnerException}");
            }
    
        }
    }
}
