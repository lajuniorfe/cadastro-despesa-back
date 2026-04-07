using CadastroDespesa.Dominio.TipoDespesas.Servicos.Strategys;

namespace CadastroDespesa.Dominio.TipoDespesas.Servicos.Factorys
{
    public interface ITipoDespesaFactory
    {
        ITipoDespesaStrategy Obter(int idTipoPagamento);

    }
}
