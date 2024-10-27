using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using CadastroDespesa.Dominio.TipoDespesas.Repositorios;
using CadastroDespesa.Infra.Contexto;
using CadastroDespesa.Infra.Contexto.Repositorios;
using CadastroDespesa.Infra.UnitOfWork.Interfaces;

namespace CadastroDespesa.Infra.TipoDespesas.Repositorios
{
    public class TipoDespesaRepositorio : BaseRepositorio<TipoDespesa>, ITipoDespesaRepositorio
    {
        public TipoDespesaRepositorio(EntityContexto context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
            
        }
    }
}
