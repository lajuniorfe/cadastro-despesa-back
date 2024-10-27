using AutoMapper;
using CadastroDespesa.Application.Despesas.Interfaces;
using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Factories.Pagamentos.Interfaces;
using CadastroDespesa.Dominio.Fatories.Pagamentos;
using CadastroDespesa.DTO.Despesas.Requests;
using CadastroDespesa.DTO.Despesas.Responses;
using CadastroDespesa.Infra.UnitOfWork.Interfaces;

namespace CadastroDespesa.Application.Despesas;

public class DespesaApp : IDespesaApp
{
    private readonly IMapper _mapper;
    private readonly IDespesasRepositorio despesasRepositorio;
    private readonly ProcessamentoPagamentoFactory _pagamentoFactory;
    private readonly IUnitOfWork unitOfWork;
    public DespesaApp(IMapper mapper, IDespesasRepositorio despesasRepositorio, ProcessamentoPagamentoFactory _pagamentoFactory, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        this._pagamentoFactory = _pagamentoFactory;
        this.despesasRepositorio = despesasRepositorio;
        this.unitOfWork = unitOfWork;
    }

    public IList<DespesaResponse> BuscarDespesas()
    {
        IEnumerable<Despesa> despesas = despesasRepositorio.ObterTodos();
        return _mapper.Map<List<DespesaResponse>>(despesas); 
    }

    public async Task CadastrarDespesa(CadastrarDespesaRequest despesaRequest)
    {
        try
        {
            unitOfWork.BeginTransaction();

            Despesa despesa = _mapper.Map<Despesa>(despesaRequest);
            despesasRepositorio.Criar(despesa);

            Cartao cartao = _mapper.Map<Cartao>(despesaRequest.Cartao);

            IPagamentoProcessar processadorPagamento = _pagamentoFactory.ProcessarPagamento(despesaRequest.TipoPagamento.Id);

            await processadorPagamento.Processar(despesa, cartao, despesaRequest.Parcela.Value);
            
            await unitOfWork.CommitAsync();
        }
        catch{
            unitOfWork.Rollback();
            throw;
        }
        

    }
}
