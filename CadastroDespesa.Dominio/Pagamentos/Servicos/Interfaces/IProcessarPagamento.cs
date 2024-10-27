using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Despesas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.Pagamentos.Servicos.Interfaces
{
    public interface IProcessarPagamento
    {
        Task ProcessarPagamento(Despesa despesa, int idCartao, int totalParcelas);
    }
}
