using CadastroDespesa.Dominio.Base.Entidades;
using CadastroDespesa.Dominio.Usuarios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.ConfiguracoesFinanceira.Entidades
{
    public class ConfiguracaoFinanceira: BaseEntidade
    {
       
        public virtual int PercentualEssencial { get; protected set; }  
        public virtual int PercentualNaoEssencial { get; protected set; }
        public virtual int PercentualInvestimento { get; protected set; }
        public virtual decimal ValorLimiteMensal { get; protected set; }
        public virtual DateTime Data {  get; protected set; }

        public virtual int IdUsuario { get; protected set; }
        public virtual Usuario Usuario { get; protected set; }
    }
}
