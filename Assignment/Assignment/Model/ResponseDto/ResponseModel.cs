using System.Net;

namespace Assignment.Model.ResponseDto
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string? Status { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}
