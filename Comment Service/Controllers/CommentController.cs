using AutoMapper;
using Comment_Service.Dto;
using Comment_Service.Models;
using Comment_Service.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Comment_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IComment _commentService;
        private readonly IPost _postService;
        private readonly IMapper _mapper;
        private readonly ResponseDto responseDto;
        public CommentController(IComment commentService, IMapper mapper, IPost postService)
        {
            _commentService = commentService;
            _postService = postService;
            _mapper = mapper;
            responseDto = new ResponseDto();
        }

        [HttpPost]
    /*    [Authorize]*/
        public  async Task<ActionResult<ResponseDto>> AddComment(CommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            var post = await  _postService.GetPostById(comment.commentId, HttpContext);
            var postVal = new PostDto();
            Console.WriteLine(post);
        string resp = await    _commentService.CreateComment(comment);
            responseDto.message = resp;
            responseDto.result = comment;
            responseDto.statusCode = HttpStatusCode.Created;
            return Created("",responseDto);    
        }


        [HttpGet("{postId}")]
        [Authorize]
        public async Task<ActionResult<ResponseDto>> GetAllComments(Guid postId){
             var comments =   await   _commentService.GetComments(postId);
             responseDto.result = comments;
             return Ok(responseDto);
        }
       [HttpGet("{commentId}")]
        [Authorize]
       public async Task<Comment> GetOneComment(Guid commentId)
        {
          var comment =  await  _commentService.GetCommentById(commentId);
            return comment;
        }
    }
}
