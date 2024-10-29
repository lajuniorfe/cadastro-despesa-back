using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Despesas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.Factories.Pagamentos.Interfaces
{
    public interface IPagamentoProcessar
    {
        Task Processar(Despesa despesa, int idCartao, int totalParcelas); 
    }
}
