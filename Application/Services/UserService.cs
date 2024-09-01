using Application.Extension;
using Domain;
using Domain.DTOs.Account;
using Domain.DTOs.User;
using InfraStructure;
using InfraStructure.Senders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService(Context context, IViewRenderService viewRenderService) : IUserService
    {


        public async Task AddUser(User user)
        {
            await context.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<List<MemberDTO>> GetAllUserInformation()
        {
            var users = await context.Users.Include(u => u.Photos).ToListAsync();
            return users.Select(x => new MemberDTO
            {
                UserId = x.UserId,
                Age = x.DateOfBirth.CalculateAge(),
                AvatarName = x.AvatarName,
                City = x.City,
                Country = x.Country,
                Email = x.Email,
                Gender = x.Gender,
                Intrests = x.Intrests,
                Introduction = x.Introduction,
                IsActiveEmail = x.IsActiveEmail,
                KnowAs = x.KnowAs,
                LookingFor = x.LookingFor,
                RegisterDate = x.RegisterDate,
                UserName = x.UserName,
                Mobile = x.Mobile,
                PhotoDTOs = x.Photos.Select(x => new PhotoDTO
                {
                    PhotoId = x.PhotoId,
                    IsMain = x.IsMain,
                    Url = x.Url,
                }).ToList()
            }).ToList();

        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<MemberDTO> GetUserInformationByUserName(string userName)
        {
            var user = await context.Users.Include(u => u.Photos).
                FirstOrDefaultAsync(u => EF.Functions.Like(u.UserName, $"%{userName.Trim()}%"));
            if (user==null)
            {
                return null;
            }
            return new MemberDTO
            {
                Age=user.DateOfBirth.CalculateAge(),
                UserName=user.UserName,
                AvatarName=user.AvatarName,
                City=user.City,
                Country=user.Country,
                Email=user.Email,
                Gender=user.Gender,
                Intrests=user.Intrests,
                Introduction=user.Introduction,
                IsActiveEmail=user.IsActiveEmail,
                KnowAs=user.KnowAs,
                LookingFor=user.LookingFor,
                Mobile=user.Mobile,
                RegisterDate=user.RegisterDate,
                UserId=user.UserId,
                PhotoDTOs=user.Photos.Select(u=>new PhotoDTO
                {
                    IsMain=u.IsMain,
                    PhotoId=u.PhotoId,
                    Url=u.Url,
                }).ToList()
            };
                
        }


            public async Task<bool> IsExistsEmail(string email)
            {
                return await context.Users.AnyAsync(u => u.Email == email);
            }

            public async Task<LoginResult> Login(LoginDTO login)
            {
                var user = await context.Users.FirstOrDefaultAsync
                    (u => u.Email == login.Email.ToLower().Trim() && u.Password == HashPassword.EncodePasswordMd5(login.Password).ToLower().Trim());

                if (user is null)
                {
                    return LoginResult.NotFound;
                }

                if (user.IsActiveEmail == false)
                {
                    return LoginResult.InActiveAccount;
                }


                return LoginResult.Success;
            }


            public async Task<RegisterResult> Register(RegisterDTO register)
            {
                if (await IsExistsEmail(register.Email))
                {
                    return RegisterResult.EmailIsExist;
                }

                User user = new User()
                {
                    UserName = register.UserName.ToLower().Trim(),
                    Email = register.Email.ToLower().Trim(),
                    Password = HashPassword.EncodePasswordMd5(register.Password),
                    IsActiveEmail = false,
                    RegisterDate = DateTime.Now,
                    AvatarName = "Defaulte.jpg"
                };
                await AddUser(user);

                SendMail.Send(register.Email, "فعالسازی حساب کاربری", viewRenderService.RenderToStringAsync("ActivateAccount", new { }));

                return RegisterResult.Success;
            }
        }
    }
