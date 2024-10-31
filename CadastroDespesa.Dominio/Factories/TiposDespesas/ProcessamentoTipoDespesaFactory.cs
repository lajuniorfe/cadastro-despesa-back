using CadastroDespesa.Dominio.Factories.TiposDespesas.Interfaces;
using CadastroDespesa.Dominio.Factories.TiposDespesas.Servicos;
using CadastroDespesa.Dominio.TipoDespesas.Servicos.Interfaces;
using CadastroDespesa.Dominio.TiposPagamento.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.Factories.TiposDespesas
{
    public class ProcessamentoTipoDespesaFactory
    {
        private readonly ITipoDespesaServico tipoDespesaServico;
        public ProcessamentoTipoDespesaFactory(ITipoDespesaServico tipoDespesaServico)
        {
            this.tipoDespesaServico = tipoDespesaServico;
        }

        public ITipoDepesaProcessar ProcessarTipoDespesa(int idTipoDespesa)
        {
            return idTipoDespesa switch
            {
                1 => new TipoDespesaFixaProcessar(),
                2 => new TipoDespesaVariavelProcessar(),
                3 => new TipoDespesaRecorrenteProcessar(),
                4 => new TipoDespesaExtraordinariaProcessar (),
                5 => new TipoDespesaEmergencialProcessar(),
                6 => new TipoDespesaConvenienciaProcessar(),
                _ => throw new ArgumentException("Tipo Despesa não suportado")
            };
        }
    }
}

