using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Factories.TiposDespesas.Servicos;
using CadastroDespesa.Dominio.Parcelas.Entidades;
using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using CadastroDespesa.Dominio.TiposPagamento.Entidades;
using CadastroDespesa.Dominio.TransacoesDespesas.Entidades;
using CadastroDespesa.Dominio.TransacoesDespesas.Repositorios;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Teste.Dominio.Factories.TiposDespesas
{
    public class TipoDespesaFixaProcessarTeste
    {
        private readonly Mock<ITransacaoDespesaRepositorio> transacaoDespesaMock;
        private readonly TipoDespesaFixaProcessar tipoDespesaFixaProcessar;
        public TipoDespesaFixaProcessarTeste()
        {
            transacaoDespesaMock = new Mock<ITransacaoDespesaRepositorio>();
            tipoDespesaFixaProcessar = new(transacaoDespesaMock.Object);
        }

        [Fact]
        public async Task Quando_Tipo_Despesa_For_Fixa_Espero_Processar_Tipo_Despesa_Fixa()
        {
            int idTipoDespesa = 1;
            int quantidadeTransacao = 2;
            bool statusPagamento = false;
            var tipoDespesa = new TipoDespesa { Id = idTipoDespesa };
            var descricao = "Despesa Teste";
            var data = DateTime.Now.Date;
            var valor = 10;
            var categoria = new Mock<Categoria>();
            var parcela = new Parcela();
            var tipoPagamento = new TipoPagamento();
            var transacaoDespesa = new TransacaoDespesa();
            int idTransacaoDespesa = 1;

            Despesa despesa = new(descricao, valor, data, categoria.Object, tipoDespesa);

            transacaoDespesaMock.Setup(t => t.Criar(transacaoDespesa)).ReturnsAsync(idTransacaoDespesa);

            await tipoDespesaFixaProcessar.Processar(despesa, tipoPagamento, quantidadeTransacao, statusPagamento, valor); ;

            await tipoDespesaFixaProcessar
                  .ProcessarTipoDespesaFixa(despesa, tipoPagamento, quantidadeTransacao, statusPagamento, valor);
        }

        [Fact]
        public async Task Quando_Ocorrer_Erro_Espero_LancarExcecao()
        {
            int idTipoDespesa = 1;
            int quantidadeTransacao = 2;
            bool statusPagamento = false;
            var tipoDespesa = new TipoDespesa { Id = idTipoDespesa };
            var descricao = "Despesa Teste";
            var data = DateTime.Now.Date;
            var valor = 10;
            var categoria = new Mock<Categoria>();
            var parcela = new Parcela();
            var tipoPagamento = new TipoPagamento();
            var transacaoDespesa = new TransacaoDespesa();
            Despesa despesa = new(descricao, valor, data, categoria.Object, tipoDespesa);

            transacaoDespesaMock
                .Setup(repo => repo.Criar(It.IsAny<TransacaoDespesa>()))
                .ThrowsAsync(new Exception("Erro ao criar transação"));

            await Assert.ThrowsAsync<Exception>(async () =>
            {
                await tipoDespesaFixaProcessar
                .ProcessarTipoDespesaFixa(despesa, tipoPagamento, quantidadeTransacao, statusPagamento, valor);
            });
        }
    }
}
