using CadastroDespesa.Dominio.TransacoesDespesas.Entidades;
using CadastroDespesa.Dominio.TransacoesDespesas.Repositorios;
using CadastroDespesa.Dominio.TransacoesDespesas.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.TransacoesDespesas.Servicos
{
    public class TransacaoDespesaServico : ITransacaoDespesaServico
    {
        private readonly ITransacaoDespesaRepositorio transacaoDespesaRepositorio;

        public TransacaoDespesaServico(ITransacaoDespesaRepositorio transacaoDespesaRepositorio)
        {
            this.transacaoDespesaRepositorio = transacaoDespesaRepositorio;
        }

        public async Task<TransacaoDespesa> ValidarTransacaoDespesaAsync(int id)
        {
            TransacaoDespesa transacaoDespesa = await transacaoDespesaRepositorio.ObterPorId(id);
            return transacaoDespesa;
        }
    }
}
