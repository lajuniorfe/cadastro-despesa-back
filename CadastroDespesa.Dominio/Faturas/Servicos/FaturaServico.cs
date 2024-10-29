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

        public async Task<Fatura> VerificarFaturaCartaoAsync(Cartao cartao, decimal valorDespesa, DateTime dataFatura)
        {
            IEnumerable<Fatura> response = await faturaRepositorio.Buscar(x =>
            x.Cartao.Id == cartao.Id
            && (x.MesCorrespondente.Month == dataFatura.Month
            && x.MesCorrespondente.Year == x.MesCorrespondente.Year));

            if (response.Any())
            {
                response.First().SetValor(response.First().Valor + valorDespesa);
                await faturaRepositorio.Alterar(response.First());
                return response.First();    
            }
                

            DateTime dataVencimento = new DateTime(dataFatura.Year, dataFatura.Month, cartao.Vencimento);

            Fatura novaFatura = new(valorDespesa, dataVencimento, dataFatura, cartao);
           
            await faturaRepositorio.Criar(novaFatura);

            return novaFatura;
        }
    }
}
