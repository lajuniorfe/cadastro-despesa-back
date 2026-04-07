using CadastroDespesa.Dominio.Recorrencias.Entidades;
using CadastroDespesa.Dominio.Recorrencias.Repositorios;
using CadastroDespesa.Dominio.Recorrencias.Servicos.Interfaces;

namespace CadastroDespesa.Dominio.Recorrencias.Servicos
{
    public class RecorrenciaServico : IRecorrenciaServico
    {
        private readonly IRecorrenciaRepositorio recorrenciaRepositorio;
        public RecorrenciaServico(IRecorrenciaRepositorio recorrenciaRepositorio)
        {
            this.recorrenciaRepositorio = recorrenciaRepositorio;
        }

        public async Task<Recorrencia> BuscarRecorrenciaNomeAsync(string Nome)
        {
            Recorrencia response = await recorrenciaRepositorio.Buscar(c => c.Nome == Nome);
            return response;
        }

        public async Task<Recorrencia> ValidarRecorrenciaAsync(int id)
        {
            return await recorrenciaRepositorio.ObterPorId(id);
        }
    }
}
