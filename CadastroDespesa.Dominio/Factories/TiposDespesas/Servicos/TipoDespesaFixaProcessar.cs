using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Factories.TiposDespesas.Servicos.Interfaces;
using CadastroDespesa.Dominio.TiposPagamento.Entidades;
using CadastroDespesa.Dominio.TransacoesDespesas.Entidades;
using CadastroDespesa.Dominio.TransacoesDespesas.Repositorios;

namespace CadastroDespesa.Dominio.Factories.TiposDespesas.Servicos
{
    public class TipoDespesaFixaProcessar : ITipoDespesaFixaProcessar
    {
        private readonly ITransacaoDespesaRepositorio transacaoDespesaRepositorio;
        public TipoDespesaFixaProcessar(ITransacaoDespesaRepositorio transacaoDespesaRepositorio)
        {
            this.transacaoDespesaRepositorio = transacaoDespesaRepositorio;
        }

        public async Task Processar(Despesa despesa, TipoPagamento tipoPagamento, int quantidadeTransacao, bool statusPagamento, decimal valorTransacao)
        {
            await ProcessarTipoDespesaFixa(despesa, tipoPagamento, quantidadeTransacao, statusPagamento, valorTransacao);
        }

        public async Task ProcessarTipoDespesaFixa(Despesa despesa, TipoPagamento tipoPagamento, int quantidadeTransacao, bool statusPagamento, decimal valorTransacao)
        {
            try
            {
                TransacaoDespesa transacaoDespesa = new();
                var dataAtual = despesa.Data;

                for (var i = 0; i < quantidadeTransacao; i++)
                {
                    transacaoDespesa = new(despesa, dataAtual, valorTransacao, tipoPagamento, statusPagamento);
                    await transacaoDespesaRepositorio.Criar(transacaoDespesa);

                    dataAtual.AddMonths(1);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
