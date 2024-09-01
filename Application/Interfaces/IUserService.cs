using Domain;
using Domain.DTOs.Account;
using Domain.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IUserService
    {

        Task<List<User>> GetAll();

        Task<User> GetUserById(int id);

        Task<User> GetUserByEmail(string email);

        Task<List<MemberDTO>> GetAllUserInformation();

        Task<MemberDTO> GetUserInformationByUserName(string userName);

        #region Account

        Task<RegisterResult> Register(RegisterDTO register);

        Task<bool> IsExistsEmail(string email);

        Task<LoginResult> Login(LoginDTO login);

        #endregion



        Task AddUser(User user);

    }
}
