using CadastroDespesa.Application.ResumosFinanceiros.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Application.ResumosFinanceiros.Interfaces
{
    public interface IResumoFinanceiroApp
    {
        Task<ResumoFinanceiroResponse> RetornarResumoFinanceiroMes();
    }
}
