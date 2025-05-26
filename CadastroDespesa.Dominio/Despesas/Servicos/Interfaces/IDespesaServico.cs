using System;
using CadastroDespesa.Dominio.Despesas.Entidades;

namespace CadastroDespesa.Dominio.Despesas.Servicos.Interfaces;

public interface IDespesaServico
{
    Task<Despesa> ValidarDespesaAsync(int idDespesa);
    Task<Despesa> InstanciaDespesaParaCadastro(string descricao, decimal valor, DateTime data, int idCategoria, int idTipoDespesa);
    Task PersistirDespesas(DespesaPersistencia request, CancellationToken cancellationToken);
}
