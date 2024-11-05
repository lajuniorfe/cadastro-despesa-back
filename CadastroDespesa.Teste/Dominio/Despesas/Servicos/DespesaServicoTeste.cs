using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.Dominio.Categorias.Servicos.Interfaces;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Despesas.Servicos;
using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using CadastroDespesa.Dominio.TipoDespesas.Servicos.Interfaces;
using Moq;

namespace CadastroDespesa.Teste.Dominio.Despesas.Servicos
{
    public class DespesaServicoTeste
    {
        private readonly Mock<IDespesaRepositorio> _despesasRepositorioMock;
        private readonly Mock<ICategoriaServico> _categoriaServicoMock;
        private readonly Mock<ITipoDespesaServico> _tipoDespesaServicoMock;
        private readonly DespesaServico _despesaServico;

        public DespesaServicoTeste()
        {
            _despesasRepositorioMock = new Mock<IDespesaRepositorio>();
            _categoriaServicoMock = new Mock<ICategoriaServico>();
            _tipoDespesaServicoMock = new Mock<ITipoDespesaServico>();

            _despesaServico = new DespesaServico(
                _despesasRepositorioMock.Object,
                _categoriaServicoMock.Object,
                _tipoDespesaServicoMock.Object);
        }

        [Fact]
        public async Task Quando_Receber_Id_Despesa_Espero_Instanciar_Despesa()
        {
            var categoriaMock = new Mock<Categoria>();
            var tipoDespesaMock = new Mock<TipoDespesa>();

            var descricao = "Despesa Teste";
            decimal valor = 200;
            DateTime data = DateTime.Now.Date;

            _categoriaServicoMock.Setup(s => s.ValidarCategoriaAsync(categoriaMock.Object.Id))
                                 .ReturnsAsync(categoriaMock.Object);

            _tipoDespesaServicoMock.Setup(s => s.ValidarTipoDespesaAsync(tipoDespesaMock.Object.Id))
                                   .ReturnsAsync(tipoDespesaMock.Object);

            var despesaCriada = await _despesaServico
                .InstanciaDespesaParaCadastro(descricao, valor, data, categoriaMock.Object.Id, tipoDespesaMock.Object.Id);


            Assert.Equal(descricao, despesaCriada.Descricao);
            Assert.Equal(valor, despesaCriada.Valor);
            Assert.Equal(data.Date, despesaCriada.Data.Date);
            Assert.Equal(categoriaMock.Object, despesaCriada.Categoria);
            Assert.Equal(tipoDespesaMock.Object, despesaCriada.TipoDespesa);
        }

        [Fact]
        public async Task Quando_Receber_Id_Despesa_Espero_Retornar_Despesa_Valida()
        {
            int idDespesa = 1;
            var despesaValida = new Mock<Despesa>();
            _despesasRepositorioMock.Setup(r => r.ObterPorId(idDespesa))
                                    .ReturnsAsync(despesaValida.Object);


            var despesaRetornada = await _despesaServico.ValidarDespesaAsync(idDespesa);

            Assert.NotNull(despesaRetornada);

        }
    }
}
