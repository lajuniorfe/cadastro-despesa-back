using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.Dominio.Categorias.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.ResumosFinanceiro.Entidades
{
    public class ResumoFinanceiro
    {
        public decimal Receita { get; private set; }

        public IList<ResumoCategoria> Categorias { get; private set; }

        public ResumoFinanceiro(decimal receita, IList<ResumoCategoria> categorias)
        {
            Receita = receita;
            Categorias = categorias;
        }
    }
}
