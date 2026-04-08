using AutoMapper;
using CadastroDespesa.Dominio.Usuarios.Entidades;
using CadastroDespesa.DTO.Usuarios.Requests;
using CadastroDespesa.DTO.Usuarios.Responses;

namespace CadastroDespesa.Application.Usuarios.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioResponse>();
            CreateMap<UsuarioRequest, Usuario>();
        }
    }
}
