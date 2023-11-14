using AuthSystem.Model;
using AuthSystem.Model.Dto;
using AuthSystem.Repositories.UsuarioRepositoryFolder;
using AuthSystem.Services.TokenServiceFolder;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;

namespace AuthSystem.Services.UsuarioServiceFolder
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;
        public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository, ITokenService tokenService)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }

        public async Task<string> LogarUsuario(UsuarioDTO usuario)
        {
            var usuarioExistenteNoBanco = await _usuarioRepository.FindUsuarioByUsername(usuario.Username);
            if (usuarioExistenteNoBanco is null || !VerifyPasswordHash(usuario.Password, usuarioExistenteNoBanco))
                return null;
            var token = _tokenService.CreateToken(usuarioExistenteNoBanco);
            return token;
        }

        public async Task<Usuario> RegistrarUsuario(UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            var usuarioCriado = await _usuarioRepository.AddUsuario(usuario);
            return usuarioCriado;
        }


        private bool VerifyPasswordHash(string password, Usuario usuario)
        {
            using (var hmac = new HMACSHA512(usuario.PasswordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(usuario.PasswordHash);
            }
        }
    }
}
