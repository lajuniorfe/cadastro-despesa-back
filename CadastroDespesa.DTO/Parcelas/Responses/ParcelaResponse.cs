using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.DTO.Parcelas.Responses
{
    public class ParcelaResponse
    {
        public int Id { get; set; }
        public decimal Valor { get; protected set; }
        public int NumeroParcela { get; protected set; }
        public DateTime Data { get; protected set; }
    }
}
