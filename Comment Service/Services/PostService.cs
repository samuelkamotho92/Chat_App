using Azure;
using Comment_Service.Dto;
using Comment_Service.Services.IServices;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Comment_Service.Services
{
    public class PostService : IPost
    {
        private IHttpClientFactory _HttpClientFactory;

        public PostService(IHttpClientFactory httpClientFactory)
        {
            _HttpClientFactory = httpClientFactory;
        }
        public async Task<PostDto> GetPostById(Guid postid, HttpContext httpContext)
        {
            var authHeader = httpContext.Request.Headers.Authorization;
            Console.WriteLine($"{authHeader}");
            var token = authHeader.ToString().Split(' ')[1];
           if (authHeader.ToString().Split(' ')[0] == "Bearer")
           {
                var client = _HttpClientFactory.CreateClient("Posts");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var resp = await client.GetAsync($"{postid}");
                Console.WriteLine($"Get value {resp}");
                var content = await resp.Content.ReadAsStringAsync();
                var respDto = JsonConvert.DeserializeObject<ResponseDto>(content);
                if (resp.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<PostDto>(Convert.ToString(respDto.result));
                }
            }
            else
            {
                Console.WriteLine("No valid authorization found");
                return new PostDto();
            }
              
            return new PostDto();
        }

    }
}
