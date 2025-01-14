using Domain;
using Presentation.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Presentation.Services.Impelementations
{
    public class TokenService : ITokenService
    {

        private readonly SymmetricSecurityKey _key;

        readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            _configuration = configuration;
        }

        public string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId , user.UserName),
                new Claim("UserID",user.UserId.ToString())
            };



            var credential = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Issuer"],claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credential
                );


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
