using AuthSystem.Model;

namespace AuthSystem.Services.TokenServiceFolder
{
    public interface ITokenService
    {
        string CreateToken(Usuario user);
        RefreshToken GenerateRefreshToken();

        void SetRefreshToken(RefreshToken refreshToken,ref Usuario usuario,HttpContext context);
    }
}
