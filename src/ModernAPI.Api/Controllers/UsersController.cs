using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModernAPI.Api.Models;
using ModernAPI.DataAccess.Context;
using ModernAPI.DataAccess.Model;
using System.Net;

namespace ModernAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _ctx;
        public UsersController(UserContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<User>> GetUser(uint id)
        {
            User? user;
            try
            {
                user = await _ctx.Users.FirstOrDefaultAsync(user => user.Id == id);
                if (user is null)
                {
                    return NotFound($"A user with id: {id} does not exist");
                }
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Something went wrong on our side.");
            }

            return Ok(user);

        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserModel createuser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                User user = new()
                {
                    UserName = createuser.UserName,
                    DateOfBirth = createuser.DateOfBirth
                };

                await _ctx.Users.AddAsync(user);
                await _ctx.SaveChangesAsync();

                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Something went wrong on our side.");
            }

        }
    }
}
