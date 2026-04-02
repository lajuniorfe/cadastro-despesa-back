using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.TiposPagamento.commands
{
    public class CartaoPagamentoCommand: PagamentoCommand
    {
        public int IdCartao { get; }
        public DateTime Data { get; }

        public CartaoPagamentoCommand(int idCartao, DateTime data)
        {
            IdCartao = idCartao;
            Data = data;
        }
    }
}
