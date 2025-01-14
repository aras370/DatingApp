using Application;
using Domain;
using Domain.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {

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

        [HttpPut("[action]")]
        [Authorize]
        public async Task<IActionResult> EditUserProfoile(UpdateMemberDTO member)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            int userid = int.Parse(User.FindFirst("UserID").Value);

         

            await userService.EditUserInformationByUser(member,userid);

            return Ok();
        }

    }
}
