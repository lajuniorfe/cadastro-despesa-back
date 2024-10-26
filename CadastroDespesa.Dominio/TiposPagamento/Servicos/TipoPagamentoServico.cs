using CadastroDespesa.Dominio.TiposPagamento.Entidades;
using CadastroDespesa.Dominio.TiposPagamento.Repositorios;
using CadastroDespesa.Dominio.TiposPagamento.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.TiposPagamento.Servicos
{
    public class TipoPagamentoServico : ITipoPagamentoServico
    {
        private readonly ITipoPagamentoRepositorio tipoPagamentoRepositorio;

        public TipoPagamentoServico(ITipoPagamentoRepositorio tipoPagamentoRepositorio)
        {
            this.tipoPagamentoRepositorio = tipoPagamentoRepositorio;
        }

        public async Task<TipoPagamento> ValidarPagamentoAsync(int id)
        {
            TipoPagamento retorno = await tipoPagamentoRepositorio.ObterPorId(id);
            return retorno;
        }
    }
}
