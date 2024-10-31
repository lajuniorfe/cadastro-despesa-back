using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Factories.TiposDespesas.Servicos.Interfaces;
using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using CadastroDespesa.Dominio.TipoDespesas.Servicos.Interfaces;
using CadastroDespesa.Dominio.TransacoesDespesas.Repositorios;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.Factories.TiposDespesas.Servicos
{
    public class TipoDespesaFixaProcessar : ITipoDespesaFixaProcessar
    {
        private readonly ITransacaoDespesaRepositorio transacaoDespesaRepositorio;
        private readonly IDespesaRepositorio despesaRepositorio;
        private readonly ITipoDespesaServico tipoDespesaServico;

        public TipoDespesaFixaProcessar(ITransacaoDespesaRepositorio transacaoDespesaRepositorio, IDespesaRepositorio despesaRepositorio, ITipoDespesaServico tipoDespesaServico)
        {
            this.transacaoDespesaRepositorio = transacaoDespesaRepositorio;
            this.despesaRepositorio = despesaRepositorio;
            this.tipoDespesaServico = tipoDespesaServico;
        }

        public async Task Processar(int idTipoDespesa, int idTipoPagamento, Despesa despesa)
        {
            await ProcessarTipoDespesaFixa(despesa, idTipoDespesa);
        }

        public async Task<int> ProcessarTipoDespesaFixa(Despesa despesa, int idTipoDespesa)
        {
            //Despesa fixa vai ser cadastrada normalmente como qualquer outra.porém, será criada
            // uma transação para o mes do cadastro.
            // Será necessário criar uma transação todos os meses para informar o valor e o pagamento

            TipoDespesa tipoDespesa = await tipoDespesaServico.ValidarTipoDespesaAsync(idTipoDespesa);
            
            if (tipoDespesa == null)
                throw new Exception("Tipo Despesa não encontrada");


            return await despesaRepositorio.Criar(despesa);
        }
    }
}
