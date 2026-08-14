using CadastroDespesa.DTO.Usuarios.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Application.ConfiguracoesFinanceiras.Dtos.Requests
{
    public class ConfiguracaoFinanceiraRequest
    {
        public int PercentualEssencial { get; set; }
        public int PercentualNaoEssencial { get; set; }
        public int PercentualInvestimento { get; set; }
        public decimal ValorLimiteMensal { get; set; }
        public DateTime Data { get; set; }
        public int IdUsuario { get; set; }
    }
}
