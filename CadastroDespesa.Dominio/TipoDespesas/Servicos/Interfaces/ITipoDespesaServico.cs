using CadastroDespesa.Dominio.TipoDespesas.Entidades;

namespace CadastroDespesa.Dominio.TipoDespesas.Servicos.Interfaces
{
    public interface ITipoDespesaServico
    {
        Task<TipoDespesa> ValidarTipoDespesaAsync(int id);
    }
}
