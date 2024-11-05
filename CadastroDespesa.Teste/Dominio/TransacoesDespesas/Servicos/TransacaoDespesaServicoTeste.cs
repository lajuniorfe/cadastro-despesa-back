using CadastroDespesa.Dominio.Parcelas.Entidades;
using CadastroDespesa.Dominio.Parcelas.Repositorios;
using CadastroDespesa.Dominio.Parcelas.Servicos;
using CadastroDespesa.Dominio.Parcelas.Servicos.Interfaces;
using CadastroDespesa.Dominio.TransacoesDespesas.Entidades;
using CadastroDespesa.Dominio.TransacoesDespesas.Repositorios;
using CadastroDespesa.Dominio.TransacoesDespesas.Servicos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Teste.Dominio.TransacoesDespesas.Servicos
{
    public class TransacaoDespesaServicoTeste
    {
        private readonly Mock<ITransacaoDespesaRepositorio> _transacaoRepositorioMock;
        private readonly TransacaoDespesaServico _transacaoDespesaServico;

        public TransacaoDespesaServicoTeste()
        {
            _transacaoRepositorioMock = new Mock<ITransacaoDespesaRepositorio>();
            _transacaoDespesaServico = new TransacaoDespesaServico(_transacaoRepositorioMock.Object);
        }

        [Fact]
        public async Task Quando_Receber_Id_TransacaoDespesa_Espero_Retornar_TransacaoDespesa_Valida()
        {
            int idTransacaoDespesa = 1;

            var transacaoValida = new Mock<TransacaoDespesa>();
            _transacaoRepositorioMock.Setup(r => r.ObterPorId(idTransacaoDespesa))
                .ReturnsAsync(transacaoValida.Object);

            var transacaoRetornada = await _transacaoDespesaServico
                .ValidarTransacaoDespesaAsync(idTransacaoDespesa);

            Assert.NotNull(transacaoRetornada);
        }
    }
}
