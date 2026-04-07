using CadastroDespesa.Dominio.Recorrencias.Servicos.Strategys;

namespace CadastroDespesa.Dominio.Recorrencias.Servicos.Factorys
{
    public interface IRecorrenciaFactory
    {
        IRecorrenciaStrategy Obter(int idTipoPagamento);

    }
}
