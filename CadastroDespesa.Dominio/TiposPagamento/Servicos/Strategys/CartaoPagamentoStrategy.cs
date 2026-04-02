using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Faturas.Servicos.Interfaces;
using CadastroDespesa.Dominio.TiposPagamento.commands;
using CadastroDespesa.Dominio.TiposPagamento.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.TiposPagamento.Servicos.Strategys
{
    public class CartaoPagamentoStrategy : IFormaPagamentoStrategy
    {
        private readonly IFaturaServico faturaServico;
        private readonly ICartaoServico cartaoServico;

        public CartaoPagamentoStrategy(ICartaoServico cartaoServico, IFaturaServico faturaServico)
        {
            this.cartaoServico = cartaoServico;
            this.faturaServico = faturaServico;
        }

        public async Task ProcessarAsync(Despesa despesa, PagamentoCommand command)
        {
            var cartaoCommand = (CartaoPagamentoCommand)command;

            var fatura = await faturaServico.VerificarFaturaCartaoAsync(cartaoCommand.IdCartao, despesa.Data);
            if(fatura is null)
            {
                Cartao cartao = await cartaoServico.ValidarCartaoAsync(cartaoCommand.IdCartao);
                fatura = await faturaServico.CriarFaturaCartaoAsync(despesa.Data, cartao);
            }

            despesa.SetFatura(fatura.Id);
        }
    }
}
