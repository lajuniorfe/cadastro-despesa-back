using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.DTO.Despesas.Requests
{
    public class AlterarDespesaRequest
    {
        public int IdDespesa { get; set; }
        public decimal ValorDespesa { get; set; }
        public DateTime DataDespesa {  get; set; }
        public string Descricao { get; set; }
        public int Parcela {  get; set; }
        public int IdCartao { get; set; }
    }
}
