using Application;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService userService;

        public UserController(IUserService user)
        {
            userService = user;
        }

      
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {

            var users = await userService.GetAllUserInformation();

            return Ok(users);

        }

       
        [HttpGet("{userName}")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            var user = await userService.GetUserInformationByUserName(userName);
            return Ok(user);
        }

    }
}
