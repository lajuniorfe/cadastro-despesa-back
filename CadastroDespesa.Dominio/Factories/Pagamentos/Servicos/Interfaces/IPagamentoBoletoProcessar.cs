using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Factories.Pagamentos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.Factories.Pagamentos.Servicos.Interfaces
{
    public interface IPagamentoBoletoProcessar : IPagamentoProcessar
    {
        Task ProcessarPagamentoBoleto(Despesa despesa);
    }
}
