using CadastroDespesa.Dominio.TransacoesDespesas.Entidades;
using CadastroDespesa.Dominio.TransacoesDespesas.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.TransacoesDespesas.Servicos.Interfaces
{
    public interface ITransacaoDespesaServico
    {
        public Task<TransacaoDespesa> ValidarTransacaoDespesaAsync(int id);
    }
}
