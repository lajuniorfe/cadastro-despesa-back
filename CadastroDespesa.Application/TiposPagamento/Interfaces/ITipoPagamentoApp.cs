using CadastroDespesa.DTO.TiposPagamento.Requests;
using CadastroDespesa.DTO.TiposPagamento.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Application.TiposPagamento.Interfaces
{
    public interface ITipoPagamentoApp
    {
        public Task CriarTipoPagamento(TipoPagamentoRequest request);
        public Task<IList<TipoPagamentoResponse>> RetornarTiposPagamento();
    }
}
