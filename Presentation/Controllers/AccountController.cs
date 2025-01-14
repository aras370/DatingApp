using Application;
using Domain;
using Domain.DTOs.Account;
using Domain.DTOs.Public;
using Presentation.Services.Interfaces;
using InfraStructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;


namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IViewRenderService viewRenderService, IUserService userService, ITokenService tokenService) : ControllerBase
    {




        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginDTO login)
        {

            LoginResult user = await userService.Login(login);

            switch (user)
            {
                case LoginResult.Success:
                    {

                        var user1 = await userService.GetUserByEmail(login.Email);


                        return new JsonResult(new ResponseResult(true, "ورود به سیستم با موفقیت انجام شد", new UserDTO
                        {
                            UserName = user1.UserName,
                            Token = tokenService.CreateToken(user1)
                        }));

                    }



                case LoginResult.NotFound:
                    {
                        return new JsonResult(new ResponseResult(false, "کاربری با مشخصات وارد شده یافت نشد"));
                    }


                case LoginResult.InActiveAccount:
                    {

                        return new JsonResult(new ResponseResult(false, "حساب کاربری شما فعال نمیباشد"));
                    }
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return new JsonResult(new ResponseResult(true, "خروج با موفقیت انجام شد"));
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDTO register)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RegisterResult result = await userService.Register(register);

            switch (result)
            {
                case RegisterResult.Success:

                    var user = await userService.GetUserByEmail(register.Email);


                    return new JsonResult(new ResponseResult(true, "ثبت نام شما با موفقیت انجام شد", new UserDTO
                    {
                        UserName = user.UserName,
                        Token = tokenService.CreateToken(user)
                    }));


                case RegisterResult.EmailIsExist:
                    {

                        return new JsonResult(new ResponseResult(false, "ایمیل وارد شده تکراری میباشد"));
                    }
            }

            return new JsonResult(new ResponseResult(false, "خطایی رخ داده است لطفا بعدا مجددا امتحان کنید"));
        }



        [HttpPost("[action]")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDTO forgotPassword)
        {
            return Ok();
        }

    }
}
