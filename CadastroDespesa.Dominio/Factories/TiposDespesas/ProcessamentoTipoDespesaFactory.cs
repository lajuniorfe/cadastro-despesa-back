using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Factories.TiposDespesas.Interfaces;
using CadastroDespesa.Dominio.Factories.TiposDespesas.Servicos;
using CadastroDespesa.Dominio.TipoDespesas.Repositorios;
using CadastroDespesa.Dominio.TipoDespesas.Servicos.Interfaces;
using CadastroDespesa.Dominio.TiposPagamento.Servicos.Interfaces;
using CadastroDespesa.Dominio.TransacoesDespesas.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.Factories.TiposDespesas
{
    public class ProcessamentoTipoDespesaFactory
    {
        private readonly ITransacaoDespesaRepositorio transacaoDespesaRepositorio;
        public ProcessamentoTipoDespesaFactory(ITransacaoDespesaRepositorio transacaoDespesaRepositorio)
        {
            this.transacaoDespesaRepositorio = transacaoDespesaRepositorio;
        }

        public ITipoDepesaProcessar ProcessarTipoDespesa(int idTipoDespesa)
        {
            return idTipoDespesa switch
            {
                1 => new TipoDespesaFixaProcessar(transacaoDespesaRepositorio),
                2 => new TipoDespesaVariavelProcessar(transacaoDespesaRepositorio),
                3 => new TipoDespesaRecorrenteProcessar(transacaoDespesaRepositorio),
                4 => new TipoDespesaExtraordinariaProcessar (transacaoDespesaRepositorio),
                5 => new TipoDespesaEmergencialProcessar(transacaoDespesaRepositorio),
                6 => new TipoDespesaConvenienciaProcessar(transacaoDespesaRepositorio),
                _ => throw new ArgumentException("Tipo Despesa não suportado")
            };
        }
    }
}

