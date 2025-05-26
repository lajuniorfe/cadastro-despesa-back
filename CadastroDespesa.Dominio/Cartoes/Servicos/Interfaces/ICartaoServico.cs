using CadastroDespesa.Dominio.Cartoes.Entidades;

namespace CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces
{
    public interface ICartaoServico
    {
        Task<Cartao> ValidarCartaoAsync(int idCartao);
        Task<Cartao> BuscarCartaoNomeAsync(string cartao);
    }
}
