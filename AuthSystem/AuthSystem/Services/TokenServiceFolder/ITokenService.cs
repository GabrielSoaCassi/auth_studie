using AuthSystem.Model;

namespace AuthSystem.Services.TokenServiceFolder
{
    public interface ITokenService
    {
        string CreateToken(Usuario user);
    }
}
