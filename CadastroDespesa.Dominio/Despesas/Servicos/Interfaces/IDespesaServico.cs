using System;
using CadastroDespesa.Dominio.Despesas.Entidades;

namespace CadastroDespesa.Dominio.Despesas.Servicos.Interfaces;

public interface IDespesaServico
{
    Task<Despesa> ValidarDespesaAsync(int idDespesa);
}
