using CadastroDespesa.Dominio.TransacoesDespesas.Entidades;
using CadastroDespesa.Dominio.TransacoesDespesas.Repositorios;
using CadastroDespesa.Infra.Contexto;
using CadastroDespesa.Infra.Contexto.Repositorios;

namespace CadastroDespesa.Infra.TransacoesDespesas.Repositorios
{
    public class TransacaoDespesaRepositorio : BaseRepositorio<TransacaoDespesa>, ITransacaoDespesaRepositorio
    {
       public TransacaoDespesaRepositorio(EntityContexto contexto) : base(contexto) { }
    }
}
