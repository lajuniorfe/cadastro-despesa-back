using CadastroDespesa.DTO.Investimentos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Application.Investimentos.Intefaces
{
    public interface IInvestimentoApp
    {
        Task<IList<InvestimentoResponse>> RetornarListaInvestimentos();
    }
}
