using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Faturas.Entidades;
using CadastroDespesa.Dominio.Parcelas.Entidades;
using CadastroDespesa.Dominio.Parcelas.Repositorios;
using CadastroDespesa.Dominio.Parcelas.Servicos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Teste.Dominio.Parcelas.Servicos
{
    public class ParcelaServicoTeste
    {
        private readonly Mock<IParcelaRepositorio> _parcelaRepositorioMock;
        private readonly ParcelaServico _parcelaServico;

        public ParcelaServicoTeste()
        {
            _parcelaRepositorioMock = new Mock<IParcelaRepositorio>();
            _parcelaServico = new ParcelaServico(_parcelaRepositorioMock.Object);
        }

        [Fact]
        public async Task Quando_Receber_Id_Parcela_Espero_Retornar_Parcela_Valida()
        {
            int idParcela = 1;

            var parcelaValida = new Mock<Parcela>();
            _parcelaRepositorioMock.Setup(r => r.ObterPorId(idParcela))
                .ReturnsAsync(parcelaValida.Object);

            var parcelaRetornada = await _parcelaServico.ValidarParcelaAsync(idParcela);

            Assert.NotNull(parcelaRetornada);
        }

        [Fact]
        public async Task Quando_Receber_Lista_Parcelas_Espero_Criar_Parcelas()
        {
            int idParcela = 1;
            var despesa = new Despesa();
            var fatura = new Fatura();
            decimal valor = 10m;
            DateTime data = DateTime.Now;
            int numeroParcela = 2;

            var parcelaValida = new Parcela(despesa, valor,numeroParcela, data, fatura);

            List<Parcela> parcelas = new List<Parcela>
            {
                parcelaValida
            };

            await _parcelaServico.CriarParcelasDespesa(parcelas, fatura);

            foreach (var parcela in parcelas) 
            {
                parcela.SetFatura(fatura);

                Assert.Equal(fatura, parcela.Fatura);
                _parcelaRepositorioMock.Setup(r => r.Criar(parcela)).ReturnsAsync(idParcela);
            }

        }

        [Fact]
        public void Quando_Chamado_Espero_Instanciar_Parcela()
        {
            var parcelaRetornada = _parcelaServico.InstanciarParcela();

            Assert.NotNull(parcelaRetornada);
        }

    }
}
