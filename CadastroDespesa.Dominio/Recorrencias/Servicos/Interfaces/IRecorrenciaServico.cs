using CadastroDespesa.Dominio.Recorrencias.Entidades;

namespace CadastroDespesa.Dominio.Recorrencias.Servicos.Interfaces
{
    public interface IRecorrenciaServico
    {
        Task<Recorrencia> ValidarRecorrenciaAsync(int id);
        Task<Recorrencia> BuscarRecorrenciaNomeAsync(string Nome);
    }
}
