using CadastroDespesa.Dominio.Parcelas.Entidades;

namespace CadastroDespesa.Dominio.Parcelas.Servicos.Interfaces
{
    public interface IParcelaServico
    {
        Task<Parcela> ValidarParcelaAsync(int idParcela);
    }
}
