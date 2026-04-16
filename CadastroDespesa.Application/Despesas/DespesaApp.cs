using AutoMapper;
using CadastroDespesa.Application.Despesas.Interfaces;
using CadastroDespesa.Dominio.Despesas.Commands;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Faturas.Entidades;
using CadastroDespesa.Dominio.Faturas.Repositorios;
using CadastroDespesa.Dominio.Recorrencias.Servicos.Factorys;
using CadastroDespesa.Dominio.TiposPagamento.Commands;
using CadastroDespesa.Dominio.TiposPagamento.Servicos.Factorys;
using CadastroDespesa.Dominio.UnirOfWork;
using CadastroDespesa.DTO.Despesas.Requests;
using CadastroDespesa.DTO.Despesas.Responses;
using CadastroDespesa.Infra.Faturas.Repositorios;

namespace CadastroDespesa.Application.Despesas;

public class DespesaApp : IDespesaApp
{
    private readonly IMapper _mapper;
    private readonly IDespesaRepositorio despesasRepositorio;
    private readonly IUnitOfWork unitOfWork;
    private readonly IFormaPagamentoFactory formaPagamentoFactory;
    private readonly IRecorrenciaFactory recorrenciaFactory;
    private readonly IDespesaRelacionamentoRepositorio despesaRelacionamentoRepositorio;
    private readonly IFaturaRepositorio faturaRepositorio;
    public DespesaApp(IMapper mapper, IDespesaRepositorio despesasRepositorio, IUnitOfWork unitOfWork, IFormaPagamentoFactory formaPagamentoFactory, IRecorrenciaFactory recorrenciaFactory, IDespesaRelacionamentoRepositorio despesaRelacionamentoRepositorio, IFaturaRepositorio faturaRepositorio)
    {
        _mapper = mapper;
        this.despesasRepositorio = despesasRepositorio;
        this.unitOfWork = unitOfWork;
        this.formaPagamentoFactory = formaPagamentoFactory;
        this.recorrenciaFactory = recorrenciaFactory;
        this.despesaRelacionamentoRepositorio = despesaRelacionamentoRepositorio;
        this.faturaRepositorio = faturaRepositorio;
    }

    public async Task<IList<DespesaResponse>> BuscarDespesas()
    {
        IEnumerable<Despesa> despesas = await despesasRepositorio.ObterTodos();
        return _mapper.Map<List<DespesaResponse>>(despesas);
    }

    public async Task<DespesaResponse> BuscarDespesasId(int id)
    {

        return _mapper.Map<DespesaResponse>(await despesasRepositorio.ObterPorId(id));
    }

    public async Task<IList<DespesaRelacionamentoResponse>> BuscarDespesasMesCorrespondente(int mes, int ano)
    {

        var retorno = await despesaRelacionamentoRepositorio.Listardireito(d => d.Data.Month == mes && d.Data.Year == ano);
        //IEnumerable<DespesaRelacionamento> retorno = await despesaRelacionamentoRepositorio.Listar(d => d.Data.Month == mes && d.Data.Year == ano);

        return _mapper.Map<IList<DespesaRelacionamentoResponse>>(retorno);
    }


    public async Task<DespesaRelacionamentoResponse> CadastrarDespesa(CadastrarDespesaRequest request)
    {
        try
        {
            await unitOfWork.BeginTransaction();

            #region criando a Despesa
            Despesa despesa = new(request.Descricao, request.Valor, request.Data, request.IdCategoria, request.idRecorrencia, request.Parcela.Value, request.idUsuario);

            Despesa retorno = await despesasRepositorio.Criar(despesa);

            #endregion


            #region Checando a recorrencia
            var recorrenciaStrategy = recorrenciaFactory.Obter(request.idRecorrencia);

            DespesaCommandBase commandDespesa = request.idRecorrencia switch
            {
                1 => new DespesaFixaCommand(request.Data, request.Valor, retorno.Id),
                2 => new DespesaParceladaCommand(request.Parcela.Value, request.Data, request.Valor, retorno.Id),
                4 => new DespesaUnicaCommand(request.Data, request.Valor, retorno.Id),
                _ => throw new Exception("Recorrencia não aceita")

            };

            IEnumerable<DespesaRelacionamento> despesasRelacionamento = recorrenciaStrategy.Criar(commandDespesa);

            var formaPagamento = formaPagamentoFactory.Obter(request.IdTipoPagamento);

            PagamentoCommandBase commandPagamento = request.IdTipoPagamento switch
            {
                1 => new CartaoPagamentoCommand(request.IdCartao!.Value, request.Data, despesasRelacionamento.ToList()),
                _ => new PagamentoSaldoCommand(request.Data, despesasRelacionamento.ToList())
            };

            IList<DespesaRelacionamento> listaDespesaRelacionamento = await formaPagamento.ProcessarAsync(commandPagamento);

            DespesaRelacionamentoResponse response = new();
            if (listaDespesaRelacionamento.Count() > 1)
            {
                var despesaRelacionamentoCriada = await despesaRelacionamentoRepositorio.CriarDespesasRetornandoPrimeira(listaDespesaRelacionamento);
                response = _mapper.Map<DespesaRelacionamentoResponse>(despesaRelacionamentoCriada);
            }
            else
            {
                var despesaRelacionamentoCriada = await despesaRelacionamentoRepositorio.CriarDespesaRetornando(listaDespesaRelacionamento.First());
                response = _mapper.Map<DespesaRelacionamentoResponse>(despesaRelacionamentoCriada);
            }

            #endregion

            await unitOfWork.CommitAsync();


            return response;
        }
        catch (Exception ex)
        {
            await unitOfWork.RollbackAsync();
            throw new Exception();
        }
    }

    public async Task ExcluirDespesa(int idDespesa)
    {
        try
        {
            var despesaRelacionamento = await despesaRelacionamentoRepositorio.Listar(d => d.IdDespesa == idDespesa);
            if (despesaRelacionamento.Count() > 0)
            {
                foreach (var i in despesaRelacionamento)
                {
                    await despesaRelacionamentoRepositorio.Deletar(i);
                }
            }

            Despesa despesa = await despesasRepositorio.ObterPorId(idDespesa);

            await despesasRepositorio.Deletar(despesa);

        }

        catch (Exception ex)
        {
            throw new Exception("Não foi possível excluir despesa");
        }
    }


}
