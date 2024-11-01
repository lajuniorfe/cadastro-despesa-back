using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Factories.TiposDespesas.Interfaces;
using CadastroDespesa.Dominio.TiposPagamento.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.Factories.TiposDespesas.Servicos.Interfaces
{
    public interface ITipoDespesaEmergencialProcessar : ITipoDepesaProcessar
    {
        Task ProcessarTipoDespesaEmergencial(Despesa despesa, TipoPagamento tipoPagamento, int quantidadeTransacao, bool statusPagamento, decimal valorTransacao);
    }
}
