using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.DTO.Cartao.Responses
{
    public class CartaoResponse
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal Limite { get; set; }
        public int Vencimento { get; set; }
        public int Fechamento { get; set; }
    }
}
