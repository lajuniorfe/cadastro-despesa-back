using CadastroDespesa.Dominio.TiposPagamento.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.TiposPagamento.Servicos.Factorys
{
    public interface IFormaPagamentoFactory
    {
        IFormaPagamentoStrategy Obter(int idTipoPagamento);
    }
}
