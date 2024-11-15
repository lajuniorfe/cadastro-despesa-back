using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Faturas.Entidades;

namespace CadastroDespesa.Dominio.Faturas.Servicos.Interfaces
{
    public interface IFaturaServico
    {
        Task<Fatura> ValidarFaturaAsync(int id);
        Task<Fatura> VerificarFaturaCartaoAsync(int idCartao, DateTime dataFatura);
        Task<Fatura> AlterarFaturaCartaoExistenteAsync(Fatura faturaCartaoExistente, decimal valorDespesa);
        Task<Fatura> CriarFaturaCartaoAsync(DateTime dataFatura, Cartao cartao, decimal valor);

    }
}
