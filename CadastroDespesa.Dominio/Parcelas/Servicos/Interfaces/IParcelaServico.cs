using CadastroDespesa.Dominio.Faturas.Entidades;
using CadastroDespesa.Dominio.Parcelas.Entidades;

namespace CadastroDespesa.Dominio.Parcelas.Servicos.Interfaces
{
    public interface IParcelaServico
    {
        Task CriarParcelasDespesa(IList<Parcela> parcelas, Fatura fatura);
        Task<Parcela> ValidarParcelaAsync(int idParcela);
        Parcela InstanciarParcela();
    }
}
