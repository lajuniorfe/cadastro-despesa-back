using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.TiposPagamento.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.TiposPagamento.Servicos.Interfaces
{
    public interface IFormaPagamentoStrategy
    {
        Task ProcessarAsync(Despesa despesa, PagamentoCommand command);
    }
}
