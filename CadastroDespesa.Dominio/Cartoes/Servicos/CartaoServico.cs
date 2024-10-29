using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Cartoes.Repositorios;
using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.Cartoes.Servicos
{
    public class CartaoServico : ICartaoServico
    {
        private readonly ICartaoRepositorio cartaoRepositorio;

        public CartaoServico(ICartaoRepositorio cartaoRepositorio)
        {
            this.cartaoRepositorio = cartaoRepositorio;
        }

        public async Task<Cartao> ValidarCartaoAsync(int idCartao)
        {
            Cartao retorno = await cartaoRepositorio.ObterPorId(idCartao);

            if (retorno is null)
                return null; 

           return retorno;
        }
    }
}
