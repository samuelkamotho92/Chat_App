using AutoMapper;
using Comment_Service.Dto;
using Comment_Service.Models;

namespace Comment_Service.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentDto,Comment>().ReverseMap();
        }
    }
}
