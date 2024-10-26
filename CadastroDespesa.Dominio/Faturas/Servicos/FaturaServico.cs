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
    }
}
