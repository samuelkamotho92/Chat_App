using Azure;
using Comment_Service.Dto;
using Comment_Service.Services.IServices;
using Newtonsoft.Json;

namespace Comment_Service.Services
{
    public class PostService : IPost
    {
        public IHttpClientFactory HttpClientFactory;

        public PostService(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }
        public async Task<PostDto> GetPostById(Guid id)
        {
                var client = HttpClientFactory.CreateClient("Posts");
                var resp = await  client.GetAsync($"{id}");
                var content = await resp.Content.ReadAsStringAsync();
                var respDto =   JsonConvert.DeserializeObject<ResponseDto>(content);
                if (resp.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<PostDto>(Convert.ToString(respDto.result));
                }
            return new PostDto();
        }

    }
}
