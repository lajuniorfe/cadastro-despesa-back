using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Despesas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces
{
    public interface ICartaoServico
    {
        Task<Cartao> ValidarCartaoAsync(int idCartao);
    }
}
