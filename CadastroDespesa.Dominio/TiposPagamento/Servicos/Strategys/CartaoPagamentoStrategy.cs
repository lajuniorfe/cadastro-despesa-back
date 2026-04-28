using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Faturas.Entidades;
using CadastroDespesa.Dominio.Faturas.Servicos.Interfaces;
using CadastroDespesa.Dominio.TiposPagamento.Commands;

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

        public async Task<IList<DespesaRelacionamento>> ProcessarAsync(PagamentoCommandBase command)
        {
            var comando = (CartaoPagamentoCommand)command;
            Cartao cartao = await cartaoServico.ValidarCartaoAsync(comando.IdCartao);

            foreach (var i in comando.DespesasRelacionamento)
            {
                DateTime dataCorreta = Fatura.CalcularDataFatura(i.Data, cartao.Fechamento, cartao.Vencimento);

                Fatura fatura = await faturaServico.VerificarFaturaCartaoAsync(comando.IdCartao, dataCorreta);
                if (fatura is null)
                {
                    fatura = await faturaServico.CriarFaturaCartaoAsync(dataCorreta, cartao);
                }

                i.SetData(dataCorreta);
                i.SetIdFatura(fatura.Id);
            }

            return comando.DespesasRelacionamento;
        }
    }
}
