using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using CadastroDespesa.Dominio.TipoDespesas.Repositorios;
using CadastroDespesa.Dominio.TipoDespesas.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.TipoDespesas.Servicos
{
    public class TipoDespesaServico : ITipoDespesaServico
    {
        private readonly ITipoDespesaRepositorio tipoDespesaRepositorio;
        public TipoDespesaServico(ITipoDespesaRepositorio tipoDespesaRepositorio)
        {
            this.tipoDespesaRepositorio = tipoDespesaRepositorio;
        }

        public Task<TipoDespesa> ValidarTipoDespesaAsync(int id)
        {
            return tipoDespesaRepositorio.ObterPorId(id);
        }
    }
}
