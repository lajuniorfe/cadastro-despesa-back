using CadastroDespesa.DTO.Faturas.Responses;

namespace CadastroDespesa.Application.Faturas.Interfaces
{
    public interface IFaturaApp
    {
        Task<IList<FaturaResponse>> BuscarFaturasMesCorrespondente(int mes);
        Task<IList<FaturaResponse>> BuscarFaturasCartaoMesCorrespondente(int mes, int cartao);
    }
}
