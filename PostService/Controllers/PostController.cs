using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostService.Data;
using PostService.Dtos;
using PostService.Models;
using PostService.Services.IService;
using System.Net;

namespace PostService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPost _postService;
        private readonly ResponseDto _responseDto;

        public PostController(IMapper mapper,IPost postService) { 
            _mapper = mapper;
            _postService = postService;
            _responseDto = new ResponseDto();
        }
        [HttpPost("Create Post")]
        public async Task<ActionResult<ResponseDto>> CreatePost(PostDto postDto)
        {
            try
            {
                var enteredPost = _mapper.Map<PostDto>(postDto);

                Post createdPost = await  _postService.CreatePost(postDto);
                _responseDto.result = createdPost;
                _responseDto.message = "Successfuly created post";
                _responseDto.statusCode = HttpStatusCode.OK;
                return Created("",_responseDto);
            }catch(Exception ex)
            {
                 _responseDto.errorMessage=ex.Message;
                return BadRequest();
            }
        }

        [HttpGet("Get Posts")]
        public async Task<ActionResult<ResponseDto>> GetPosts()
        {
            try
            {
                var posts = _postService.GetPosts();
                _responseDto.result = posts;
                _responseDto.message = "Posts retrived successfully";
                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.errorMessage=ex.Message;
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto>> GetPostById(Guid postid)
        {
            try
            {
                Post post =  await _postService.GetpostbyId(postid);
                _responseDto.result = post;
                _responseDto.message = "Post retrived successfully";
                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.errorMessage = ex.Message;
                return BadRequest();
            }
        }
        [HttpGet("updatePost/{id}")]
        public async Task<ActionResult<ResponseDto>> UpdatePostById(Guid postid)
        {
            try
            {
                Post post = await _postService.UpdatePost(postid);
                _responseDto.result = post;
                _responseDto.message = "Post Updated successfully";
                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.errorMessage = ex.Message;
                return BadRequest();
            }
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ResponseDto>> DeletePostById(Guid postid)
        {
            try
            {
                string resp = await _postService.DeletePosts(postid);              
                _responseDto.message = resp;
                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.errorMessage = ex.Message;
                return BadRequest();
            }
        }


    }
}
