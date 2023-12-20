using System.Net;

namespace PostService.Dtos
{
    public class ResponseDto
    {
        public string message { get; set; }

        public object result { get; set; }

        public HttpStatusCode statusCode { get; set; }

        public string errorMessage { get; set; }
    }
}
