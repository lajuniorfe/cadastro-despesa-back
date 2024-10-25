using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using CadastroDespesa.Dominio.TipoDespesas.Repositorios;
using CadastroDespesa.Infra.Contexto;
using CadastroDespesa.Infra.Contexto.Repositorios;

namespace CadastroDespesa.Infra.TipoDespesas.Repositorios
{
    public class TipoDespesaRepositorio : BaseRepositorio<TipoDespesa>, ITipoDespesaRepositorio
    {
        public TipoDespesaRepositorio(EntityContexto context) : base(context)
        {
            
        }
    }
}
