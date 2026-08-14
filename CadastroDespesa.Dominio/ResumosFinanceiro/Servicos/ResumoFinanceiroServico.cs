using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.Dominio.Categorias.Enums;
using CadastroDespesa.Dominio.ConfiguracoesFinanceira.Entidades;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.ResumosFinanceiro.Entidades;
using CadastroDespesa.Dominio.ResumosFinanceiro.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.ResumosFinanceiro.Servicos
{
    public class ResumoFinanceiroServico : IResumoFinanceiroServico
    {
        public ResumoFinanceiro Calcular(ConfiguracaoFinanceira configuracao, IEnumerable<Despesa> despesas)
        {
            var categorias = new List<ResumoCategoria>();
            var receita = despesas.Where(x => x.Categoria.Tipo == (int)TipoCategoriaEnum.Receita).Sum(x => x.Valor);

            decimal gastoEssencial = despesas.Where(x => x.Categoria.Tipo == (int)TipoCategoriaEnum.Essencial).Sum(x => x.Valor);
            decimal gastoNaoEssencial = despesas.Where(x => x.Categoria.Tipo == (int)TipoCategoriaEnum.NaoEssencial).Sum(x => x.Valor);
            decimal gastoInvestimento = despesas.Where(x => x.Categoria.Tipo == (int)TipoCategoriaEnum.Investimento).Sum(x => x.Valor);

            categorias.Add(new ResumoCategoria(TipoCategoriaEnum.Essencial, gastoEssencial, receita * configuracao.PercentualEssencial / 100));
            categorias.Add(new ResumoCategoria(TipoCategoriaEnum.NaoEssencial, gastoNaoEssencial, receita * configuracao.PercentualNaoEssencial / 100));
            categorias.Add(new ResumoCategoria(TipoCategoriaEnum.Investimento, gastoInvestimento, receita * configuracao.PercentualInvestimento / 100));


            return new ResumoFinanceiro(
                receita,
                categorias
            );

        }
    }
}
