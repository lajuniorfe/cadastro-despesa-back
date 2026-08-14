using CadastroDespesa.Dominio.ConfiguracoesFinanceira.Entidades;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.ResumosFinanceiro.Entidades;

namespace CadastroDespesa.Dominio.ResumosFinanceiro.Servicos.Interfaces
{
    public interface IResumoFinanceiroServico
    {
        ResumoFinanceiro Calcular( ConfiguracaoFinanceira configuracao, IEnumerable<Despesa> despesas);
    }
}
