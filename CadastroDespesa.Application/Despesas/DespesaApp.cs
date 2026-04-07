using AutoMapper;
using CadastroDespesa.Application.Despesas.Interfaces;
using CadastroDespesa.Dominio.Despesas.Commands;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Recorrencias.Servicos.Factorys;
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
    private readonly IFormaPagamentoFactory formaPagamentoFactory;
    private readonly IRecorrenciaFactory tipoDespesaFactory;
    public DespesaApp(IMapper mapper, IDespesaRepositorio despesasRepositorio, IUnitOfWork unitOfWork, IFormaPagamentoFactory formaPagamentoFactory, IRecorrenciaFactory tipoDespesaFactory)
    {
        _mapper = mapper;
        this.despesasRepositorio = despesasRepositorio;
        this.unitOfWork = unitOfWork;
        this.formaPagamentoFactory = formaPagamentoFactory;
        this.tipoDespesaFactory = tipoDespesaFactory;
    }

    public async Task<IList<DespesaResponse>> BuscarDespesas()
    {
        IEnumerable<Despesa> despesas = await despesasRepositorio.ObterTodos();
        return _mapper.Map<List<DespesaResponse>>(despesas);
    }

    public async Task<IList<DespesaResponse>> BuscarDespesasMesCorrespondente(int mes)
    {
        var retorno = await despesasRepositorio.Listar(d => d.Data.Month == mes);
        var tt = _mapper.Map<IList<DespesaResponse>>(retorno);

        return tt;
    }

    public async Task CadastrarDespesa(CadastrarDespesaRequest despesaRequest)
    {
        try
        {
            await unitOfWork.BeginTransaction();

            var tipoDespesaStrategy = tipoDespesaFactory.Obter(despesaRequest.idRecorrencia);

            DespesaCommand commandDespesa = despesaRequest.idRecorrencia switch
            {

                2 => new DespesaParceladaCommand(
                   despesaRequest.Parcela.Value,
                   despesaRequest.Descricao,
                   despesaRequest.Data,
                   despesaRequest.Valor,
                   despesaRequest.IdCategoria,
                   despesaRequest.IdTipoPagamento),

                _ => new DespesaCommandBase(
                    despesaRequest.Descricao,
                    despesaRequest.Data,
                    despesaRequest.Valor,
                    despesaRequest.IdCategoria,
                    despesaRequest.IdTipoPagamento)
            };

            IEnumerable<Despesa> despesas = tipoDespesaStrategy.Criar(commandDespesa);

            var formaPagamento = formaPagamentoFactory.Obter(despesaRequest.IdTipoPagamento);

            PagamentoCommand commandPagamento = despesaRequest.IdTipoPagamento switch
            {
                1 => new CartaoPagamentoCommand(despesaRequest.IdCartao!.Value, despesaRequest.Data),
                _ => new PagamentoCommandBase()
            };

            foreach (var despesa in despesas)
            {
                await formaPagamento.ProcessarAsync(despesa, commandPagamento);
                await despesasRepositorio.Criar(despesa);
            }

            await unitOfWork.CommitAsync();


            //if (despesaRequest.IdTipoDespesa == 1)
            //{
            //    despesas = new List<Despesa>
            //    {
            //        Despesa.CriarFixa(
            //            despesaRequest.Descricao ?? ""
            //          , despesaRequest.Valor
            //          , despesaRequest.Data
            //          , despesaRequest.IdCategoria
            //          , despesaRequest.IdTipoDespesa)
            //    };
            //}
            //else if ((despesaRequest.Parcela ?? 1) > 1)
            //{
            //    int totalParcelas = despesaRequest.Parcela ?? 1;
            //    despesas = Despesa.CriarParcelada(despesaRequest.Descricao ?? ""
            //          , despesaRequest.Valor
            //          , despesaRequest.Data
            //          , despesaRequest.IdCategoria
            //          , despesaRequest.IdTipoDespesa
            //          , totalParcelas);
            //}
            //else
            //{
            //    despesas = new List<Despesa>
            //    {
            //        Despesa.CriarSemParcela(
            //            despesaRequest.Descricao ?? ""
            //          , despesaRequest.Valor
            //          , despesaRequest.Data
            //          , despesaRequest.IdCategoria
            //          , despesaRequest.IdTipoDespesa)
            //    };
            //}

        }
        catch
        {
            await unitOfWork.RollbackAsync();
            throw new Exception();
        }
    }
}
