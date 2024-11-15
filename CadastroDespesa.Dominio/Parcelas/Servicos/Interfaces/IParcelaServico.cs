using CadastroDespesa.Dominio.Faturas.Entidades;
using CadastroDespesa.Dominio.Parcelas.Entidades;

namespace CadastroDespesa.Dominio.Parcelas.Servicos.Interfaces
{
    public interface IParcelaServico
    {
        Task CriarParcelasDespesa(Parcela parcela);
        Task<Parcela> ValidarParcelaAsync(int idParcela);
        Parcela InstanciarParcela();
    }
}
