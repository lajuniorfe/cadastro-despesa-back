using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Factories.TiposDespesas.Servicos.Interfaces;
using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using CadastroDespesa.Dominio.TipoDespesas.Servicos.Interfaces;
using System;

namespace CadastroDespesa.Dominio.Factories.TiposDespesas.Servicos
{
    public class TipoDespesaVariavelProcessar : ITipoDespesaVariavelProcessar
    {
        private readonly ITipoDespesaServico tipoDespesaServico;
        private readonly IDespesaRepositorio despesaRepositorio;

        public TipoDespesaVariavelProcessar(ITipoDespesaServico tipoDespesaServico, IDespesaRepositorio despesaRepositorio)
        {
            this.tipoDespesaServico = tipoDespesaServico;
            this.despesaRepositorio = despesaRepositorio;
        }

        public async Task Processar(int idTipoDespesa, int idTipoPagamento, Despesa despesa)
        {
            await ProcessarTipoDespesaVariavel(idTipoDespesa, despesa);
        }

        public async Task<int> ProcessarTipoDespesaVariavel(int idTipoDespesa, Despesa despesa)
        {

            //Despesa variavel, será cadastrada normalmente. porém, será criada uma transação para o mês cadastrado
            // Será necessário criar uma transação todos os meses para informar o valor e o pagamento

            TipoDespesa tipoDespesa = await tipoDespesaServico.ValidarTipoDespesaAsync(idTipoDespesa);

            if (tipoDespesa == null)
                throw new Exception("Tipo Despesa não encontrada");


            return await despesaRepositorio.Criar(despesa);
        }
    }
}
