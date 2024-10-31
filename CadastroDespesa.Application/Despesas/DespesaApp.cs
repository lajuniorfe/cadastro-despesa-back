using AutoMapper;
using CadastroDespesa.Application.Despesas.Interfaces;
using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;
using CadastroDespesa.Dominio.Categorias.Entidades;
using CadastroDespesa.Dominio.Categorias.Servicos.Interfaces;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Despesas.Servicos.Interfaces;
using CadastroDespesa.Dominio.Factories.Pagamentos.Interfaces;
using CadastroDespesa.Dominio.Factories.TiposDespesas;
using CadastroDespesa.Dominio.Fatories.Pagamentos;
using CadastroDespesa.Dominio.TipoDespesas.Entidades;
using CadastroDespesa.Dominio.TipoDespesas.Servicos.Interfaces;
using CadastroDespesa.Dominio.TiposPagamento.Entidades;
using CadastroDespesa.Dominio.TiposPagamento.Servicos.Interfaces;
using CadastroDespesa.Dominio.UnirOfWork;
using CadastroDespesa.DTO.Despesas.Requests;
using CadastroDespesa.DTO.Despesas.Responses;

namespace CadastroDespesa.Application.Despesas;

public class DespesaApp : IDespesaApp
{
    private readonly IMapper _mapper;
    private readonly IDespesaRepositorio despesasRepositorio;
    private readonly ProcessamentoPagamentoFactory _pagamentoFactory;
    private readonly ProcessamentoTipoDespesaFactory _tipoDespesaFactory;
    private readonly IUnitOfWork unitOfWork;
    private readonly ICartaoServico cartaoServico;
    private readonly IDespesaServico despesaServico;
    public DespesaApp(IMapper mapper, IDespesaRepositorio despesasRepositorio, ProcessamentoPagamentoFactory _pagamentoFactory, IUnitOfWork unitOfWork, ICartaoServico cartaoServico, ProcessamentoTipoDespesaFactory tipoDespesaFactory, IDespesaServico despesaServico)
    {
        _mapper = mapper;
        this._pagamentoFactory = _pagamentoFactory;
        this.despesasRepositorio = despesasRepositorio;
        this.unitOfWork = unitOfWork;
        this.cartaoServico = cartaoServico;
        _tipoDespesaFactory = tipoDespesaFactory;
        this.despesaServico = despesaServico;
    }

    public async Task<IList<DespesaResponse>> BuscarDespesas()
    {
        IEnumerable<Despesa> despesas = await despesasRepositorio.ObterTodos();
        return _mapper.Map<List<DespesaResponse>>(despesas); ;
    }

    public async Task CadastrarDespesa(CadastrarDespesaRequest despesaRequest)
    {
        try
        {

            //usar fluent validator
            await unitOfWork.BeginTransaction();

            Despesa despesa = await despesaServico
                .InstanciaDespesaParaCadastro(despesaRequest.Descricao, despesaRequest.Valor, despesaRequest.IdCategoria, despesaRequest.IdTipoDespesa, despesaRequest.IdTipoPagamento);

            await despesasRepositorio.Criar(despesa);

            IPagamentoProcessar processadorPagamento = _pagamentoFactory.ProcessarPagamento(despesaRequest.IdTipoPagamento);

            await processadorPagamento
                .Processar(
                    despesa,
                    despesaRequest.IdCartao.HasValue ?
                    despesaRequest.IdCartao.Value : 0,
                    despesaRequest.Parcela.HasValue ?
                    despesaRequest.Parcela.Value : 0
                );

            await unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            //criar log
            Console.WriteLine($"Erro: {ex.Message}");
            throw;
        }


    }
}
