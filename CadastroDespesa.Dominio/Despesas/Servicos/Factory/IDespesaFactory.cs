using CadastroDespesa.Dominio.Despesas.Servicos.Strategys;
using CadastroDespesa.Dominio.TiposPagamento.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.Despesas.Servicos.Factory
{
    public interface IDespesaFactory
    {
        IDespesaStrategy Obter(int idTipoPagamento);

    }
}
