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
        void CadastrarCartao(CartaoRequest request);
        CartaoResponse AlterarCartao(CartaoRequest request);
        CartaoResponse BuscarCartao(int id);
        IList<CartaoResponse> BuscarCartoes();
        void ExcluirCartao(int id);
    }
}
