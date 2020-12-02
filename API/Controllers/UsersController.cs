using System;
using System.Threading.Tasks;
using Assignment1.Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Assignment2API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        /*[HttpGet]
        public async Task<ActionResult<IList<User>>> GetUsers() {
            try {
                IList<User> users = await userService.allUsersAsync();
                return Ok(users);
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }*/

        [HttpGet]
        public async Task<ActionResult<User>> ValidateUser([FromQuery] string username, [FromQuery] string password)
        {
            Console.WriteLine("Here");
            try
            {
                var user = await userService.ValidateUser(username, password);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}