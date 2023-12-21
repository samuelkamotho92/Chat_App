using AutoMapper;
using PostService.Dtos;
using PostService.Models;

namespace PostService.Profiles
{
    public class PostProfile:Profile
    {
        public PostProfile()
        {
            CreateMap<PostDto, Post>().ReverseMap();
        }
    }
}
