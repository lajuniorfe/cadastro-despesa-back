using CadastroDespesa.Dominio.Faturas.Entidades;
using CadastroDespesa.Dominio.Faturas.Repositorios;
using CadastroDespesa.Infra.Contexto;
using CadastroDespesa.Infra.Contexto.Repositorios;
using CadastroDespesa.Infra.UnitOfWork.Interfaces;

namespace CadastroDespesa.Infra.Faturas.Repositorios
{
    public class FaturaRepositorio : BaseRepositorio<Fatura>, IFaturaRepositorio
    {
        FaturaRepositorio(EntityContexto context, IUnitOfWork unitOfWork): base(context, unitOfWork) { }
    }
}
