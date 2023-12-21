using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostService.Data;
using PostService.Dtos;
using PostService.Migrations;
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
        private readonly PostDbContext _postDbContext;

        public PostController(IMapper mapper,IPost postService,PostDbContext postDbContext) { 
            _mapper = mapper;
            _postService = postService;
            _responseDto = new ResponseDto();
            _postDbContext = postDbContext;
        }
        [HttpPost("Create Post")]
        [Authorize]
        public async Task<ActionResult<ResponseDto>> CreatePost(PostDto postDto)
        {
            try
            {
                var newProd = _mapper.Map<Models.Post>(postDto);
                string response = await  _postService.CreatePost(newProd);
                Console.WriteLine(response);
                _responseDto.result = postDto;
                _responseDto.message = response;
                _responseDto.statusCode = HttpStatusCode.OK;
                return Created("",_responseDto);
            }catch(Exception ex)
            {
                 _responseDto.errorMessage=ex.Message;
                return BadRequest(_responseDto);
            }
        }

        [HttpGet("Get Posts")]
        [Authorize]
        public async Task<ActionResult<ResponseDto>> GetPosts()
        {
            try
            {
                var posts = _postService.GetPosts();
                _responseDto.result = posts.Result;
                _responseDto.message = "Posts retrived successfully";
                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.errorMessage=ex.Message;
                return BadRequest();
            }
        }

        [HttpGet("{postid}")]
        [Authorize]
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
                return BadRequest(_responseDto);
            }
        }
        [HttpPut("updatePost/{postid}")]
        [Authorize]
        public async Task<ActionResult<ResponseDto>> UpdatePostById(Guid postid,PostDto updatedPost)
        {
            try
            {
                //get the post
                Post post1 = await _postService.GetpostbyId(postid);
                if(post1 != null)
                {
                    var newPost =  _mapper.Map(updatedPost, post1);
                    string resp = await _postService.UpdatePost(newPost);
                    _responseDto.result = updatedPost;
                    _responseDto.message = resp;
                    return Ok(_responseDto);
                }
                _responseDto.message = "not found";
                return NotFound(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.errorMessage = ex.Message;
                return BadRequest(_responseDto);
            }
        }
        [HttpDelete("delete/{postid}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseDto>> DeletePostById(Guid postid)
        {
            try
            {
                var post = await _postService.GetpostbyId(postid);
                string resp = await _postService.DeletePosts(post);              
                _responseDto.message = resp;
                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.errorMessage = ex.Message;
                return BadRequest(_responseDto);
            }
        }


    }
}
