using System;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Factories.Pagamentos.Interfaces;

namespace CadastroDespesa.Dominio.Factories.Pagamentos.Servicos.Interfaces;

public interface IPagamentoCartaoProcessar : IPagamentoProcessar
{
    Task ProcessarPagamentoCartao(Despesa despesa, int idCartao, int totalParcelas);
}
