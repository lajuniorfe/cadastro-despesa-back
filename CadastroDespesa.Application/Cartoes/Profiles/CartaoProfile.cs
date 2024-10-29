using AutoMapper;
using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.DTO.Cartao.Requests;
using CadastroDespesa.DTO.Cartao.Responses;
using CadastroDespesa.DTO.Cartoes.Requests;

namespace CadastroDespesa.Application.Cartoes.Profiles
{
    public class CartaoProfile : Profile
    {
        public CartaoProfile()
        {
            CreateMap<Cartao, CartaoResponse>();
            CreateMap<CadastrarCartaoRequest, Cartao>();
            CreateMap<CartaoRequest, Cartao>();
        }
    }
}
