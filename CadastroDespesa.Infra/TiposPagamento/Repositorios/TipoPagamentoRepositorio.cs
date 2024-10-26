using CadastroDespesa.Dominio.TiposPagamento.Entidades;
using CadastroDespesa.Dominio.TiposPagamento.Repositorios;
using CadastroDespesa.Infra.Contexto;
using CadastroDespesa.Infra.Contexto.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Infra.TiposPagamento.Repositorios
{
    public class TipoPagamentoRepositorio : BaseRepositorio<TipoPagamento>, ITipoPagamentoRepositorio
    {
        public TipoPagamentoRepositorio(EntityContexto context) : base(context) { }
    }
}
