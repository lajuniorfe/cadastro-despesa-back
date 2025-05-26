using CadastroDespesa.Dominio.Categorias.Entidades;

namespace CadastroDespesa.Dominio.Categorias.Servicos.Interfaces
{
    public interface ICategoriaServico
    {
        public Task<Categoria> ValidarCategoriaAsync(int id);
        public Task<Categoria> BuscarCategoriaNomeAsync(string Nome);
    }
}
