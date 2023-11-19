using AuthSystem.Model.Dto;
using AuthSystem.Services.UsuarioServiceFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private  IUsuarioService _usuarioService { get; set;}

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(UsuarioDTO usuarioDTO)
        {
            var response = await _usuarioService.RegistrarUsuario(usuarioDTO);
            if(response is null) return BadRequest("Erro ao tentar cadastrar usuário, contate o administrador do sistema");
            return Created(nameof(_usuarioService.RegistrarUsuario), response);
        }

        [HttpPost("logar")]
        public async Task<IActionResult> Logar(UsuarioDTO usuarioDTO)
        {
            var response = await _usuarioService.LogarUsuario(usuarioDTO,HttpContext);
            if(response is null) return BadRequest("Erro ao tentar logar usuário, verifique usuario e/ou senha ");
            return Created(nameof(_usuarioService.LogarUsuario), response);
        }
    }
}
