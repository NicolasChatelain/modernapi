using System.Net;

namespace ModernAPI.Api.Models
{
    public class Error
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
