using CadastroDespesa.Dominio.Investimentos.Enums;
using CadastroDespesa.DTO.Usuarios.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.DTO.Investimentos.Requests
{
    public class InvestimentoRequest
    {
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public int Tipo { get; set; }
        public DateTime Data { get; set; }
        public int IdUsuario { get; set; }
    }
}
