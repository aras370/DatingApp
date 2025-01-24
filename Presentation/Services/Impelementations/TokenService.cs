using Domain;
using Presentation.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Services.Impelementations
{
    public class TokenService : ITokenService
    {

        private readonly SymmetricSecurityKey _key;
        private readonly Context context;
        readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration, Context context)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            _configuration = configuration;
            this.context = context;
        }

        public string CreateToken(User user)
        {


            var roles = context.UserRoles.Include(ur => ur.Role).Where(ur => ur.UserID == user.UserId).Select(ur => ur.Role.RoleName).ToList();
            var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.NameId , user.UserName),
                    new Claim("UserID",user.UserId.ToString()),
                    new Claim("Role",string.Join(",", roles))
                };

            var credential = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Issuer"], claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credential
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
