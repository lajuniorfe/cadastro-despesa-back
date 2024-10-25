using AutoMapper;
using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.DTO.Cartao.Requests;
using CadastroDespesa.DTO.Cartao.Responses;

namespace CadastroDespesa.Application.Cartoes.Profiles
{
    public class CartaoProfile : Profile
    {
        public CartaoProfile()
        {
            CreateMap<Cartao, CartaoResponse>();
            CreateMap<CartaoRequest, Cartao>();
        }
    }
}
