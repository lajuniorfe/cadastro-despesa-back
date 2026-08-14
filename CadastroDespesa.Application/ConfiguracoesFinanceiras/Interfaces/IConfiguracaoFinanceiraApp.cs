using CadastroDespesa.Application.ConfiguracoesFinanceiras.Dtos.Responses;

namespace CadastroDespesa.Application.ConfiguracoesFinanceiras.Interfaces
{
    public interface IConfiguracaoFinanceiraApp
    {
        Task<ConfiguracaoFinanceiraResponse> RetornarConfiguracaoFinanceira();
    }
}
