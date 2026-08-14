using CadastroDespesa.Dominio.Categorias.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Application.ResumosFinanceiros.Dtos.Responses
{
    public class ResumoFinanceiroResponse
    {
        public decimal Receita { get; private set; }

        public IList<ResumoCategoria> Categorias { get; private set; }
    }
}
