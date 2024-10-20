using System;
using CadastroDespesa.Dominio.Despesas.Entidades;

namespace CadastroDespesa.Dominio.Despesas.Repositorios;

public interface IDespesasRepositorio
{
    void CadastroDespesa(Despesa despesas);
    Despesa Recuperar(int idDespesa);
}
