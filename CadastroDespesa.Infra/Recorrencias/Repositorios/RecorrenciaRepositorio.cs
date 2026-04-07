using CadastroDespesa.Dominio.Recorrencias.Entidades;
using CadastroDespesa.Dominio.Recorrencias.Repositorios;
using CadastroDespesa.Infra.Contexto;
using CadastroDespesa.Infra.Contexto.Repositorios;

namespace CadastroDespesa.Infra.Recorrencias.Repositorios
{
    public class RecorrenciaRepositorio : BaseRepositorio<Recorrencia>, IRecorrenciaRepositorio
    {
        public RecorrenciaRepositorio(EntityContexto context) : base(context)
        {

        }
    }
}
