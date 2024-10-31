using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Factories.TiposDespesas.Servicos.Interfaces;
using CadastroDespesa.Dominio.TransacoesDespesas.Entidades;
using CadastroDespesa.Dominio.TransacoesDespesas.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.Factories.TiposDespesas.Servicos
{
    public class TipoDespesaEmergencialProcessar : ITipoDespesaEmergencialProcessar
    {
        private readonly ITransacaoDespesaRepositorio transacaoDespesaRepositorio;

        public TipoDespesaEmergencialProcessar(ITransacaoDespesaRepositorio transacaoDespesaRepositorio)
        {
            this.transacaoDespesaRepositorio = transacaoDespesaRepositorio;
        }

        public async Task Processar(Despesa despesa, int quantidadeTransacao, bool statusPagamento, decimal valorTransacao)
        {
            await ProcessarTipoDespesaEmergencial(despesa, quantidadeTransacao, statusPagamento, valorTransacao);
        }

        public async Task ProcessarTipoDespesaEmergencial(Despesa despesa, int quantidadeTransacao, bool statusPagamento, decimal valorTransacao)
        {
            try
            {
                TransacaoDespesa transacaoDespesa = new();
                var dataAtual = despesa.Data;

                for (var i = 0; i < quantidadeTransacao; i++)
                {
                    transacaoDespesa = new(despesa, dataAtual, valorTransacao, despesa.TipoPagamento, statusPagamento);
                    await transacaoDespesaRepositorio.Criar(transacaoDespesa);

                    dataAtual.AddMonths(1);
                }
            }
            catch
            {
                throw;
            }

           
        }
    }
}
