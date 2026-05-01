using AutoMapper;
using CadastroDespesa.Application.Despesas.Interfaces;
using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Cartoes.Servicos.Interfaces;
using CadastroDespesa.Dominio.Despesas.Commands;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Faturas.Entidades;
using CadastroDespesa.Dominio.Faturas.Repositorios;
using CadastroDespesa.Dominio.Faturas.Servicos.Interfaces;
using CadastroDespesa.Dominio.Recorrencias.Servicos.Factorys;
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
    private readonly IRecorrenciaFactory recorrenciaFactory;
    private readonly IDespesaRelacionamentoRepositorio despesaRelacionamentoRepositorio;
    private readonly IFaturaRepositorio faturaRepositorio;
    private readonly ICartaoServico cartaoServico;
    private readonly IFaturaServico faturaServico;
    public DespesaApp(IMapper mapper, IDespesaRepositorio despesasRepositorio, IUnitOfWork unitOfWork, IFormaPagamentoFactory formaPagamentoFactory, IRecorrenciaFactory recorrenciaFactory, IDespesaRelacionamentoRepositorio despesaRelacionamentoRepositorio, IFaturaRepositorio faturaRepositorio, ICartaoServico cartaoServico, IFaturaServico faturaServico)
    {
        _mapper = mapper;
        this.despesasRepositorio = despesasRepositorio;
        this.unitOfWork = unitOfWork;
        this.formaPagamentoFactory = formaPagamentoFactory;
        this.recorrenciaFactory = recorrenciaFactory;
        this.despesaRelacionamentoRepositorio = despesaRelacionamentoRepositorio;
        this.faturaRepositorio = faturaRepositorio;
        this.cartaoServico = cartaoServico;
        this.faturaServico = faturaServico;
    }

    public async Task<IList<DespesaRelacionamento>> AlterarDespesa(AlterarDespesaRequest request)
    {
        await unitOfWork.BeginTransaction();

        IEnumerable<DespesaRelacionamento> listaDespesasRelacionadas = await despesaRelacionamentoRepositorio.Listardireito(d => d.IdDespesa == request.IdDespesa);
        DespesaRelacionamento despesaRelacionada = listaDespesasRelacionadas.ToList().FirstOrDefault();
        IList<DespesaRelacionamento> listaOriginal = listaDespesasRelacionadas.ToList();


        despesaRelacionada.Despesa.SetValor(request.ValorDespesa);
        despesaRelacionada.Despesa.SetDescricao(request.Descricao);

        if (despesaRelacionada.Fatura.IdCartao != request.IdCartao || request.DataDespesa != despesaRelacionada.Despesa.Data)
        {
            Cartao cartao = await cartaoServico.ValidarCartaoAsync(request.IdCartao);

            var retornado = await AlteraDataDespesasRelacionadas(request, listaOriginal, cartao);
            despesaRelacionada.Despesa.SetData(request.DataDespesa);
            listaOriginal = retornado;
        }


        if ((despesaRelacionada.Despesa.Recorrencia.Id == 2) && request.Parcela != listaOriginal[0].TotalParcela)
        {

            var listaTrabalho = listaOriginal.ToList();
            var retorno = await AlteraQuantidadeParcelas(request, listaTrabalho, listaOriginal);
            listaOriginal = retorno;
        }

        var tt = listaOriginal;

        await despesaRelacionamentoRepositorio.AlterarLista(listaOriginal);

        var retornarDespesasAlteradaa = await despesaRelacionamentoRepositorio.Listardireito(d => d.IdDespesa == request.IdDespesa);

        await unitOfWork.CommitAsync();

        return retornarDespesasAlteradaa.ToList();
    }

    private async Task<IList<DespesaRelacionamento>> AlteraQuantidadeParcelas(AlterarDespesaRequest request, IList<DespesaRelacionamento> listaTrabalho, IList<DespesaRelacionamento> listaOriginal)
    {
        var recebida = DespesaRelacionamento.AlterarParcelas(listaTrabalho, request.ValorDespesa, request.DataDespesa, request.Parcela);

        var novos = recebida.Where(x => x.Id == 0).ToList();

        if (novos.Count() > 0)
        {
            await despesaRelacionamentoRepositorio.CriarLista(novos);
        }

        var existentes = recebida.Where(x => x.Id != 0).ToList();
        //await despesaRelacionamentoRepositorio.AlterarLista(existentes);

        var idsRecebida = recebida
                 .Where(x => x.Id != 0)
                 .Select(x => x.Id)
                 .ToHashSet();

        var removidos = listaOriginal
            .Where(x => !idsRecebida.Contains(x.Id))
            .ToList();


        if (removidos.Count() > 0)
        {
            await despesaRelacionamentoRepositorio.DeletarLista(removidos);
        }

        return recebida;
    }
    private async Task<IList<DespesaRelacionamento>> AlteraDataDespesasRelacionadas(AlterarDespesaRequest request, IList<DespesaRelacionamento> listaDespesasRelacionadas, Cartao cartao)
    {
        DateTime dataCorreta = request.DataDespesa;

        for (int index = listaDespesasRelacionadas.Count - 1; index >= 0; index--)
        {
            var i = listaDespesasRelacionadas[index];

            dataCorreta = Fatura.CalcularDataFatura(dataCorreta, cartao.Fechamento, cartao.Vencimento);

            if (dataCorreta.Year == request.DataDespesa.Year)
            {
                Fatura fatura = await faturaServico.VerificarFaturaCartaoAsync(cartao.Id, dataCorreta);

                if (fatura == null)
                {
                    fatura = await faturaServico.CriarFaturaCartaoAsync(dataCorreta, cartao);
                }

                i.SetValor(request.ValorDespesa);
                i.SetData(dataCorreta);
                i.SetIdFatura(fatura.Id);
                
            }
            else
            {
                listaDespesasRelacionadas.RemoveAt(index);
                await despesaRelacionamentoRepositorio.Deletar(i);
            }
        }

        return listaDespesasRelacionadas;

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
        return _mapper.Map<IList<DespesaRelacionamentoResponse>>(retorno.OrderByDescending(a => a.Despesa.Data));
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

                response.Despesa.IdTipoPagamento = request.IdTipoPagamento;
            }
            else
            {
                var despesaRelacionamentoCriada = await despesaRelacionamentoRepositorio.CriarDespesaRetornando(listaDespesaRelacionamento.First());
                response = _mapper.Map<DespesaRelacionamentoResponse>(despesaRelacionamentoCriada);
                response.Despesa.IdTipoPagamento = request.IdTipoPagamento;
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
