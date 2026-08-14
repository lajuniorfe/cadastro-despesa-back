using CadastroDespesa.Dominio.Usuarios.Entidades;
using CadastroDespesa.DTO.Usuarios.Responses;

namespace CadastroDespesa.Application.ConfiguracoesFinanceiras.Dtos.Responses
{
    public class ConfiguracaoFinanceiraResponse
    {
        public int PercentualEssencial { get; set; }
        public int PercentualNaoEssencial { get; set; }
        public int PercentualInvestimento { get; set; }
        public decimal ValorLimiteMensal { get; set; }
        public DateTime Data { get; set; }
        public UsuarioResponse Usuario { get; set; }
    }
}
