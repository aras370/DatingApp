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



        public TokenService(IConfiguration configuration)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }

        public string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId , user.UserName)
            };
            
            var credential=new SigningCredentials(_key,SecurityAlgorithms.HmacSha512);

            var TokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires=DateTime.Now.AddDays(30),
                SigningCredentials= credential
            };

            var tokenhandler = new JwtSecurityTokenHandler();

            var token = tokenhandler.CreateToken(TokenDescriptor);

            return tokenhandler.WriteToken(token);
        }
    }
}
