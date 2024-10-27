using System;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Infra.Contexto;
using CadastroDespesa.Infra.Contexto.Repositorios;
using CadastroDespesa.Infra.UnitOfWork.Interfaces;


namespace CadastroDespesa.Infra.Despesas.Repositorios;

public class DespesaRepositorio : BaseRepositorio<Despesa>, IDespesasRepositorio
{
    public DespesaRepositorio(EntityContexto context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
    {
    }
   
}
