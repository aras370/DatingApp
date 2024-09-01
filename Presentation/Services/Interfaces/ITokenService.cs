using Domain;

namespace Presentation.Services.Interfaces
{
    public interface ITokenService
    {

        string CreateToken(User user);

    }
}
