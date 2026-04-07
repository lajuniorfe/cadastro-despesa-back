using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.TiposPagamento.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.TiposPagamento.Servicos.Strategys
{
    public class SaldoPagamentoStrategy : IFormaPagamentoStrategy
    {
        Task IFormaPagamentoStrategy.ProcessarAsync(Despesa despesa, PagamentoCommand command)
        {
            return Task.CompletedTask;
        }
    }
}
