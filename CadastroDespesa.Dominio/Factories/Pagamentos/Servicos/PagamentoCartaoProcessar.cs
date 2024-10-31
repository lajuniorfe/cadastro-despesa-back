﻿using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Factories.Pagamentos.Servicos.Interfaces;
using CadastroDespesa.Dominio.Factories.TiposDespesas;
using CadastroDespesa.Dominio.Factories.TiposDespesas.Interfaces;
using CadastroDespesa.Dominio.Faturas.Entidades;
using CadastroDespesa.Dominio.Faturas.Servicos.Interfaces;
using CadastroDespesa.Dominio.Parcelas.Entidades;
using CadastroDespesa.Dominio.Parcelas.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.Factories.Pagamentos.Servicos
{
    public class PagamentoCartaoProcessar : IPagamentoCartaoProcessar
    {
        private readonly ICartaoServico cartaoServico;
        private readonly IFaturaServico faturaServico;
        private readonly IParcelaServico parcelaServico;
        private readonly ProcessamentoTipoDespesaFactory _tipoDespesaFactory;

        public PagamentoCartaoProcessar(ICartaoServico cartaoServico, IFaturaServico faturaServico, IParcelaServico parcelaServico, ProcessamentoTipoDespesaFactory tipoDespesaFactory)
        {
            this.cartaoServico = cartaoServico;
            this.faturaServico = faturaServico;
            this.parcelaServico = parcelaServico;
            _tipoDespesaFactory = tipoDespesaFactory;
        }

        public async Task Processar(Despesa despesa, int? idCartao, int? totalParcelas)
        {
            await ProcessarPagamentoCartao(despesa, idCartao, totalParcelas);
        }

        public async Task ProcessarPagamentoCartao(Despesa despesa, int? idCartao, int? totalParcelas)
        {
            Cartao cartaoRetornado = await cartaoServico.ValidarCartaoAsync(idCartao.Value);
            Fatura faturaRetornada = await faturaServico.VerificarFaturaCartaoAsync(cartaoRetornado, despesa.Valor, despesa.Data);

            Parcela parcela = parcelaServico.InstanciarParcela();

            IList<Parcela> parcelas = parcela.CalcularDataParcela(totalParcelas.Value, despesa);
            await parcelaServico.CriarParcelasDespesa(parcelas, faturaRetornada);

            ITipoDepesaProcessar processadorTipoDespesa =  _tipoDespesaFactory.ProcessarTipoDespesa(despesa.TipoDespesa.Id);

            await processadorTipoDespesa.Processar(despesa, parcelas.Count, true, parcelas[0].Valor);

        }
    }
}
