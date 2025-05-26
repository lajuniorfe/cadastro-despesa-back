using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using CadastroDespesa.Dominio.TipoDespesas.Repositorios;
using CadastroDespesa.Dominio.TipoDespesas.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.TipoDespesas.Servicos
{
    public class TipoDespesaServico : ITipoDespesaServico
    {
        private readonly ITipoDespesaRepositorio tipoDespesaRepositorio;
        public TipoDespesaServico(ITipoDespesaRepositorio tipoDespesaRepositorio)
        {
            this.tipoDespesaRepositorio = tipoDespesaRepositorio;
        }

        public async Task<TipoDespesa> BuscarTipoDespesaNomeAsync(string Nome)
        {
            TipoDespesa response = await tipoDespesaRepositorio.Buscar(c => c.Nome == Nome);
            return response;
        }

        public async Task<TipoDespesa> ValidarTipoDespesaAsync(int id)
        {
            return await tipoDespesaRepositorio.ObterPorId(id);
        }
    }
}
