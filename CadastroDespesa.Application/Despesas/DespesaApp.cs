using System;
using AutoMapper;
using CadastroDespesa.Application.Despesas.Interfaces;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.DTO.Despesas.Requests;

namespace CadastroDespesa.Application.Despesas;

public class DespesaApp : IDespesaApp
{
    private readonly IMapper _mapper;
    private readonly IDespesasRepositorio despesasRepositorio;

    public DespesaApp(IMapper mapper, IDespesasRepositorio despesasRepositorio)
    {
        _mapper = mapper;
        this.despesasRepositorio = despesasRepositorio;
    }

    public void CadastrarDespesa(DespesaRequest despesaRequest)
    {
        Despesa despesa = _mapper.Map<Despesa>(despesaRequest);
        despesasRepositorio.CadastroDespesa(despesa);
    }
}
