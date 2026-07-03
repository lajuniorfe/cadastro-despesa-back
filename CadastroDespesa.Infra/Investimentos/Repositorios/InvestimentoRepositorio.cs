using CadastroDespesa.Dominio.Investimentos.Entidades;
using CadastroDespesa.Dominio.Investimentos.Repositorios;
using CadastroDespesa.Infra.Contexto;
using CadastroDespesa.Infra.Contexto.Repositorios;

namespace CadastroDespesa.Infra.Investimentos.Repositorios
{
    public class InvestimentoRepositorio: BaseRepositorio<Investimento>, IInvestimentoRepositorio
    {
        public InvestimentoRepositorio(EntityContexto context) : base(context) { }
    }
}
