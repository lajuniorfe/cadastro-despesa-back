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
using CadastroDespesa.Dominio.TiposPagamento.Entidades;
using CadastroDespesa.Dominio.TiposPagamento.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.Factories.Pagamentos.Servicos
{
    public class PagamentoCartaoProcessar : IPagamentoCartaoProcessar
    {
        private readonly ICartaoServico cartaoServico;
        private readonly IFaturaServico faturaServico;
        private readonly IParcelaServico parcelaServico;
        private readonly ProcessamentoTipoDespesaFactory _tipoDespesaFactory;
        private readonly ITipoPagamentoServico tipoPagamentoServico;

        public PagamentoCartaoProcessar(ICartaoServico cartaoServico, IFaturaServico faturaServico, IParcelaServico parcelaServico, ProcessamentoTipoDespesaFactory tipoDespesaFactory, ITipoPagamentoServico tipoPagamentoServico)
        {
            this.cartaoServico = cartaoServico;
            this.faturaServico = faturaServico;
            this.parcelaServico = parcelaServico;
            _tipoDespesaFactory = tipoDespesaFactory;
            this.tipoPagamentoServico = tipoPagamentoServico;
        }

        public async Task Processar(Despesa despesa, int? idCartao, int? totalParcelas)
        {
            await ProcessarPagamentoCartao(despesa, idCartao.HasValue? idCartao.Value : 0, totalParcelas.HasValue ? totalParcelas.Value : 0);
        }

        public async Task ProcessarPagamentoCartao(Despesa despesa, int idCartao, int totalParcelas)
        {
            Cartao cartaoRetornado = await cartaoServico.ValidarCartaoAsync(idCartao);
            Fatura faturaRetornada = await faturaServico.VerificarFaturaCartaoAsync(idCartao, despesa.Valor, despesa.Data);

            if (faturaRetornada != null)
            {
                faturaRetornada = await faturaServico.AlterarFaturaCartaoExistenteAsync(faturaRetornada, despesa.Valor);
            }
            else
            {
                faturaRetornada = await faturaServico.CriarFaturaCartaoAsync(despesa.Data, cartaoRetornado, despesa.Valor);
            }

            IList<Parcela> parcelas = Parcela.CalcularDataParcela(
                totalParcelas,
                despesa);
            await parcelaServico.CriarParcelasDespesa(parcelas, faturaRetornada);

            ITipoDepesaProcessar processadorTipoDespesa = _tipoDespesaFactory.ProcessarTipoDespesa(despesa.TipoDespesa is not null ? despesa.TipoDespesa.Id : 0);

            TipoPagamento tipoPagamento = await tipoPagamentoServico.ValidarPagamentoAsync(2);

            await processadorTipoDespesa.Processar(despesa, tipoPagamento, parcelas.Count, true, parcelas[0].Valor);

        }
    }
}
