using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace AuthSystem.Model
{
    public class Usuario:BaseModel
    {
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Role { get; set; }    
        public string? RefreshToken { get; set; } = string.Empty;
        public DateTime? TokenCreated { get; set; }
        public DateTime? TokenExpires { get; set; }

        public Usuario(){}
        public Usuario(string username,string password)
        {
            Username = username;
            CreatePasswordHash(password);
            Role = "user";
        }
        private void CreatePasswordHash(string password)
        {
            using( var hmac = new HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        
    }
}
