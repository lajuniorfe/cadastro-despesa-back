using CadastroDespesa.DTO.Cartao.Requests;
using CadastroDespesa.DTO.Cartao.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Application.Cartoes.Interfaces
{
    public interface ICartaoApp
    {
        Task CadastrarCartao(CadastrarCartaoRequest request);
        Task<CartaoResponse> AlterarCartao(CadastrarCartaoRequest request);
        Task<CartaoResponse> BuscarCartao(int id);
        Task<IList<CartaoResponse>> BuscarCartoes();
        Task ExcluirCartao(int id);
    }
}
