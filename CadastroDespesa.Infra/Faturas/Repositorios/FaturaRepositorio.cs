using CadastroDespesa.Dominio.Faturas.Entidades;
using CadastroDespesa.Dominio.Faturas.Repositorios;
using CadastroDespesa.Infra.Contexto;
using CadastroDespesa.Infra.Contexto.Repositorios;

namespace CadastroDespesa.Infra.Faturas.Repositorios
{
    public class FaturaRepositorio : BaseRepositorio<Fatura>, IFaturaRepositorio
    {
        public FaturaRepositorio(EntityContexto context): base(context) { }
    }
}
