using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModernAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("users")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
