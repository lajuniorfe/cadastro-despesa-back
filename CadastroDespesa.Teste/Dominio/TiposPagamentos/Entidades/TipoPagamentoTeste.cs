using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Faturas.Entidades;
using CadastroDespesa.Dominio.Parcelas.Entidades;
using CadastroDespesa.Dominio.TiposPagamento.Entidades;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
