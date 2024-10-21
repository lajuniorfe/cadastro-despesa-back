using System;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Infra.Contexto;
using CadastroDespesa.Infra.Contexto.Repositorios;


namespace CadastroDespesa.Infra.Despesas.Repositorios;

public class DespesaRepositorio : BaseRepositorio<Despesa>, IDespesasRepositorio
{
    public DespesaRepositorio(EntityContexto context) : base(context)
    {
    }
   
}
