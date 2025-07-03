using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModernAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Success");
        }
    }
}
