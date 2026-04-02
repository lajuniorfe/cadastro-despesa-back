using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Faturas.Entidades;
using CadastroDespesa.Dominio.Faturas.Repositorios;
using CadastroDespesa.Dominio.Faturas.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.Faturas.Servicos
{
    public class FaturaServico : IFaturaServico
    {
        private readonly IFaturaRepositorio faturaRepositorio;

        public FaturaServico(IFaturaRepositorio faturaRepositorio)
        {
            this.faturaRepositorio = faturaRepositorio;
        }

        public async Task<Fatura> ValidarFaturaAsync(int id)
        {
            return await faturaRepositorio.ObterPorId(id);
        }

        public async Task<Fatura> VerificarFaturaCartaoAsync(int idCartao, DateTime dataFatura)
        {
            Fatura response = await faturaRepositorio.Buscar(x =>
            x.Cartao.Id == idCartao
            && (x.MesCorrespondente.Month == dataFatura.Month
            && x.MesCorrespondente.Year == dataFatura.Year));

            return response;
        }

        public async Task<Fatura> AlterarFaturaCartaoExistenteAsync(Fatura faturaCartaoExistente)
        {
            await faturaRepositorio.Alterar(faturaCartaoExistente);
            return faturaCartaoExistente;
        }

        public async Task<Fatura> CriarFaturaCartaoAsync(DateTime dataFatura, Cartao cartao)
        {
            DateTime dataVencimento = new DateTime(dataFatura.Year, dataFatura.Month, cartao.Vencimento);

            Fatura novaFatura = new(dataVencimento, dataFatura, cartao.Id);

            await faturaRepositorio.Criar(novaFatura);

            return novaFatura;
        }

        public async Task<IList<Fatura>> ListarFaturasCartaoAsync(int idCartao)
        {
            IEnumerable<Fatura> response = await faturaRepositorio.Listar(x =>
            x.IdCartao == idCartao);

            return response.ToList();
        }
    }
}
