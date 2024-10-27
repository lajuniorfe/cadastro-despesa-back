using AutoMapper;
using CadastroDespesa.Application.Despesas.Interfaces;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Pagamentos.Servicos.Interfaces;
using CadastroDespesa.DTO.Despesas.Requests;
using CadastroDespesa.DTO.Despesas.Responses;

namespace CadastroDespesa.Application.Despesas;

public class DespesaApp : IDespesaApp
{
    private readonly IMapper _mapper;
    private readonly IDespesasRepositorio despesasRepositorio;
    private readonly IProcessarPagamento processarPagamento;
    public DespesaApp(IMapper mapper, IDespesasRepositorio despesasRepositorio, IProcessarPagamento processarPagamento)
    {
        _mapper = mapper;
        this.processarPagamento = processarPagamento;
    }

    public IList<DespesaResponse> BuscarDespesas()
    {
        return _mapper.Map<List<DespesaResponse>>(despesasRepositorio.ObterTodos());
    }

    public async Task CadastrarDespesa(CadastrarDespesaRequest despesaRequest)
    {
        Despesa despesa = _mapper.Map<Despesa>(despesaRequest);
        await despesasRepositorio.Criar(despesa);

        await processarPagamento.ProcessarPagamento(despesa, despesaRequest.Cartao.Id, despesaRequest.Parcela.Value);

    }
}
