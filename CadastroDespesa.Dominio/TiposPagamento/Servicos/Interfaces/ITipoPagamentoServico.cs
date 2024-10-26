using CadastroDespesa.Dominio.TiposPagamento.Entidades;
using CadastroDespesa.Dominio.TiposPagamento.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.TiposPagamento.Servicos.Interfaces
{
    public interface ITipoPagamentoServico
    {
        Task<TipoPagamento> ValidarPagamentoAsync(int id);
    }
}
