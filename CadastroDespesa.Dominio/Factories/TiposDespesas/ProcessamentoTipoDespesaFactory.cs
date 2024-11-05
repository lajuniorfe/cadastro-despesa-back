using CadastroDespesa.Dominio.Factories.TiposDespesas.Interfaces;
using CadastroDespesa.Dominio.Factories.TiposDespesas.Servicos;
using CadastroDespesa.Dominio.TransacoesDespesas.Repositorios;

namespace CadastroDespesa.Dominio.Factories.TiposDespesas
{
    public class ProcessamentoTipoDespesaFactory
    {
        private readonly ITransacaoDespesaRepositorio transacaoDespesaRepositorio;
        public ProcessamentoTipoDespesaFactory(ITransacaoDespesaRepositorio transacaoDespesaRepositorio)
        {
            this.transacaoDespesaRepositorio = transacaoDespesaRepositorio;
        }

        public virtual ITipoDepesaProcessar ProcessarTipoDespesa(int idTipoDespesa)
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

