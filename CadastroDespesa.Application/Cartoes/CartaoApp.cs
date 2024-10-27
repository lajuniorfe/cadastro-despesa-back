using AutoMapper;
using CadastroDespesa.Application.Cartoes.Interfaces;
using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Cartoes.Repositorios;
using CadastroDespesa.Dominio.Cartoes.Servicos;
using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;
using CadastroDespesa.DTO.Cartao.Requests;
using CadastroDespesa.DTO.Cartao.Responses;
using NHibernate.Mapping.ByCode.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Application.Cartoes
{
    public class CartaoApp : ICartaoApp
    {
        private readonly ICartaoRepositorio cartaoRepositorio;
        private readonly IMapper _mapper;
        private readonly ICartaoServico cartaoServico;


        public CartaoApp(ICartaoRepositorio cartaoRepositorio, IMapper mapper, ICartaoServico cartaoServico)
        {
            this.cartaoRepositorio = cartaoRepositorio;
            _mapper = mapper;
            this.cartaoServico = cartaoServico;
        }

        public CartaoResponse AlterarCartao(CadastrarCartaoRequest request)
        {
            Cartao cartao = _mapper.Map<Cartao>(request);
            cartaoRepositorio.Alterar(cartao);
            return _mapper.Map<CartaoResponse>(cartao);
        }

        public CartaoResponse BuscarCartao(int id)
        {
            return _mapper.Map<CartaoResponse>(cartaoRepositorio.ObterPorId(id));
        }

        public IList<CartaoResponse> BuscarCartoes()
        {
            IEnumerable<Cartao> cartao = cartaoRepositorio.ObterTodos();
            IList<CartaoResponse> response = _mapper.Map<IList<CartaoResponse>>(cartao);
            return response;
        }

        public void CadastrarCartao(CadastrarCartaoRequest request)
        {
            Cartao cartao = _mapper.Map<Cartao>(request);
            cartaoRepositorio.Criar(cartao);
        }

        public async void ExcluirCartao(int id)
        {
            Cartao retorno = await cartaoServico.ValidarCartaoAsync(id);
            await cartaoRepositorio.Deletar(retorno);
        }
    }
}
