using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.DTO.TiposPagamento.Requests
{
    public class TipoPagamentoRequest
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
    }
}
