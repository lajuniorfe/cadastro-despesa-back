using CadastroDespesa.Dominio.Base.Repositorios;
using CadastroDespesa.Dominio.Despesas.Entidades;
using System.Linq.Expressions;

namespace CadastroDespesa.Dominio.Despesas.Repositorios
{
    public  interface IDespesaRelacionamentoRepositorio : IBaseRepositorio<DespesaRelacionamento>
    {
        Task<DespesaRelacionamento> CriarDespesaRetornando(DespesaRelacionamento despesa);
        Task<DespesaRelacionamento> CriarDespesasRetornandoPrimeira(IList<DespesaRelacionamento> despesas);

        Task<IEnumerable<DespesaRelacionamento>> Listardireito(Expression<Func<DespesaRelacionamento, bool>> predicate);
    }
}
