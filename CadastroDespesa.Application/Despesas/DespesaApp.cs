using AutoMapper;
using CadastroDespesa.Application.Despesas.Interfaces;
using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;
using CadastroDespesa.Dominio.Categorias.Servicos.Interfaces;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Despesas.Servicos.Interfaces;
using CadastroDespesa.Dominio.Faturas.Servicos.Interfaces;
using CadastroDespesa.Dominio.TipoDespesas.Servicos.Interfaces;
using CadastroDespesa.Dominio.TiposPagamento.commands;
using CadastroDespesa.Dominio.TiposPagamento.Commands;
using CadastroDespesa.Dominio.TiposPagamento.Servicos.Factorys;
using CadastroDespesa.Dominio.UnirOfWork;
using CadastroDespesa.DTO.Despesas.Requests;
using CadastroDespesa.DTO.Despesas.Responses;

namespace CadastroDespesa.Application.Despesas;

public class DespesaApp : IDespesaApp
{
    private readonly IMapper _mapper;
    private readonly IDespesaRepositorio despesasRepositorio;
    private readonly IUnitOfWork unitOfWork;
    private readonly IDespesaServico despesaServico;
    private readonly ICategoriaServico categoriaServico;
    private readonly ITipoDespesaServico tipoDespesaServico;
    private readonly ICartaoServico cartaoServico;
    private readonly IFaturaServico faturaServico;
    private readonly IFormaPagamentoFactory formaPagamentoFactory;
    public DespesaApp(IMapper mapper, IDespesaRepositorio despesasRepositorio, IUnitOfWork unitOfWork, IDespesaServico despesaServico, ICategoriaServico categoriaServico, ITipoDespesaServico tipoDespesaServico, ICartaoServico cartaoServico, IFaturaServico faturaServico, IFormaPagamentoFactory formaPagamentoFactory)
    {
        _mapper = mapper;
        this.despesasRepositorio = despesasRepositorio;
        this.unitOfWork = unitOfWork;
        this.despesaServico = despesaServico;
        this.categoriaServico = categoriaServico;
        this.tipoDespesaServico = tipoDespesaServico;
        this.cartaoServico = cartaoServico;
        this.faturaServico = faturaServico;
        this.formaPagamentoFactory = formaPagamentoFactory;
    }

    public async Task<IList<DespesaResponse>> BuscarDespesas()
    {
        IEnumerable<Despesa> despesas = await despesasRepositorio.ObterTodos();
        return _mapper.Map<List<DespesaResponse>>(despesas);
    }


    public async Task CadastrarDespesa(CadastrarDespesaRequest despesaRequest)
    {
        try
        {
            await unitOfWork.BeginTransaction();

            IEnumerable<Despesa> despesas;

            int totalParcelas = despesaRequest.Parcela ?? 1;
            if ((despesaRequest.Parcela ?? 1) > 1)
            {
                despesas = Despesa.CriarParcelada(despesaRequest.Descricao ?? ""
                      , despesaRequest.Valor
                      , despesaRequest.Data
                      , despesaRequest.IdCategoria
                      , despesaRequest.IdTipoDespesa
                      , totalParcelas);
            }
            else
            {
                despesas = new List<Despesa>
                {
                    Despesa.CriarSemParcela(
                        despesaRequest.Descricao ?? ""
                      , despesaRequest.Valor
                      , despesaRequest.Data
                      , despesaRequest.IdCategoria
                      , despesaRequest.IdTipoDespesa)
                };
            }

            var formaPagamento = formaPagamentoFactory.Obter(despesaRequest.IdTipoPagamento);

            PagamentoCommand command = despesaRequest.IdTipoPagamento switch
            {
                1 => new CartaoPagamentoCommand(despesaRequest.IdCartao!.Value, despesaRequest.Data),
                _ => new PagamentoCommandBase()
            };

            foreach ( var despesa in despesas)
            {
                await formaPagamento.ProcessarAsync(despesa, command);
                await despesasRepositorio.Criar(despesa);
            }

            await unitOfWork.CommitAsync();
        }
        catch
        {
            await unitOfWork.RollbackAsync();
            throw new Exception();
        }
    }
}
