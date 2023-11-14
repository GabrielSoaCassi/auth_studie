using AuthSystem.Model;
using AuthSystem.Model.Dto;
using AutoMapper;

namespace AuthSystem.Profiles
{
    public class UsuarioProfile:Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuario>();
        }
    }
}
