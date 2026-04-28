using CadastroDespesa.DTO.Faturas.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.DTO.Despesas.Responses
{
    public class DespesaRelacionamentoResponse
    {
        public int Id { get; set; }
        public virtual int NumeroParcela { get; protected set; }
        public virtual int TotalParcela { get; protected set; }
        public virtual decimal Valor { get; protected set; }
        public virtual DateTime Data { get; protected set; }
        public DespesaResponse Despesa { get; set; }
        public virtual FaturaResponse Fatura { get; protected set; }
       
    }
}
