using CadastroDespesa.Dominio.Faturas.Entidades;
using CadastroDespesa.Dominio.Parcelas.Entidades;
using CadastroDespesa.Dominio.Parcelas.Repositorios;
using CadastroDespesa.Dominio.Parcelas.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.Parcelas.Servicos
{
    public class ParcelaServico : IParcelaServico
    {
        private readonly IParcelaRepositorio parcelaRepositorio;

        public ParcelaServico(IParcelaRepositorio parcelaRepositorio)
        {
            this.parcelaRepositorio = parcelaRepositorio;
        }

        public async Task CriarParcelasDespesa(IList<Parcela> parcelas, Fatura fatura)
        {
            foreach (var i in parcelas)
            {
                i.SetFatura(fatura);
                parcelaRepositorio.Criar(i);
            }
        }

        public async Task<Parcela> ValidarParcelaAsync(int idParcela)
        {
            return await parcelaRepositorio.ObterPorId(idParcela);
        }

        public Parcela InstanciarParcela()
        {
            return new Parcela();
        }
    }
}
