using AutoMapper;
using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.DTO.Categorias.Requests;
using CadastroDespesa.DTO.Categorias.Responses;

namespace CadastroDespesa.Application.Categorias.Profiles
{
    public class CategoriaProfile: Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, CategoriaResponse>();
            CreateMap<CategoriaRequest, Categoria>();
        }
    }
}
