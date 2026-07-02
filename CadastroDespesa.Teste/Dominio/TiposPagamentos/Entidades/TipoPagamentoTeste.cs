using CadastroDespesa.Dominio.TiposPagamento.Entidades;

namespace CadastroDespesa.Teste.Dominio.TiposPagamentos.Entidades
{
    public class TipoPagamentoTeste
    {
        [Fact]
        public void Quando_Instanciar_Pacela_Espero_Valores_Validos()
        {
           string nome = "Tipo Pagamento Teste";

            TipoPagamento tipoPagamento = new TipoPagamento(nome);

            Assert.Equal(nome, tipoPagamento.Nome);
        }
    }
}
