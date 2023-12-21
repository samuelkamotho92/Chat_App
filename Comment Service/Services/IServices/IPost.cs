using Comment_Service.Dto;

namespace Comment_Service.Services.IServices
{
    public interface IPost
    {

        Task<PostDto> GetPostById(Guid postid, HttpContext httpContext);

    }
}
