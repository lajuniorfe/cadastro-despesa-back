using AutoMapper;
using CadastroDespesa.Application.ConfiguracoesFinanceiras.Dtos.Responses;
using CadastroDespesa.Application.ConfiguracoesFinanceiras.Interfaces;
using CadastroDespesa.Application.Despesas.Interfaces;
using CadastroDespesa.Application.Notifications.Interfaces;
using CadastroDespesa.Dominio.Categorias.Enums;
using CadastroDespesa.Dominio.ConfiguracoesFinanceira.Entidades;
using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.ResumosFinanceiro.Entidades;
using CadastroDespesa.Dominio.ResumosFinanceiro.Servicos.Interfaces;
using CadastroDespesa.DTO.Despesas.Responses;
using CadastroDespesa.DTO.Notifications.Requests;
using System.Collections.Concurrent;
using System.Threading.Channels;

namespace CadastroDespesa.Application.Notifications;

public class NotificationServices : INotificationServices, IDisposable
{
    private readonly ConcurrentDictionary<Guid, Channel<NotificationMessageRequest>> _subscribers = new();
    //private readonly IConfiguracaoFinanceiraApp configuracaoFinanceiraApp;
    //private readonly IDespesaApp despesaApp;
    //private readonly IResumoFinanceiroServico resumoFinanceiroServico;
    //private readonly IMapper _mapper;
    //public NotificationServices(IConfiguracaoFinanceiraApp configuracaoFinanceiraApp, IDespesaApp despesaApp, IResumoFinanceiroServico resumoFinanceiroServico, IMapper mapper)
    //{
    //    this.configuracaoFinanceiraApp = configuracaoFinanceiraApp;
    //    this.despesaApp = despesaApp;
    //    this.resumoFinanceiroServico = resumoFinanceiroServico;
    //    _mapper = mapper;
    //}

    public ChannelReader<NotificationMessageRequest> Subscribe(CancellationToken ct)
    {
        var channel = Channel.CreateUnbounded<NotificationMessageRequest>(new UnboundedChannelOptions
        {
            SingleReader = true,
            SingleWriter = false
        });

        var id = Guid.NewGuid();

        _subscribers.TryAdd(id, channel);

        ct.Register(() =>
        {
            _subscribers.TryRemove(id, out _);
            channel.Writer.TryComplete();
        });

        return channel.Reader;
    }

    public async Task NotifyAsync(NotificationMessageRequest message, CancellationToken ct = default)
    {
        foreach (var subscriber in _subscribers.Values)
        {
            try
            {
                await subscriber.Writer.WriteAsync(message, ct);
            }
            catch
            {
                // Ignora conexões encerradas
            }
        }
    }

    public Task SendConnectedMessage(CancellationToken ct)
    {
        return NotifyAsync(new NotificationMessageRequest
        {
            Title = "Conexão",
            Message = "SSE conectado",
            Type = "info"
        }, ct);
    }


    public void Dispose()
    {
        foreach (var ch in _subscribers.Values)
            ch.Writer.TryComplete();
        _subscribers.Clear();
    }

    public async Task<NotificationMessageRequest> NotificarGastoAcimaLimite(CancellationToken ct = default)
    {
    //    IList<DespesaRelacionamentoResponse> despesasMes = await despesaApp.BuscarDespesasMesCorrespondente(7, 2026);

    //    IEnumerable<DespesaResponse> despesas = despesasMes.Select(x => x.Despesa);

    //    ConfiguracaoFinanceiraResponse retornoConfiguracao = await configuracaoFinanceiraApp.RetornarConfiguracaoFinanceira();

    //    ResumoFinanceiro resumo = resumoFinanceiroServico.Calcular(
    //        _mapper.Map<ConfiguracaoFinanceira>(retornoConfiguracao),
    //        _mapper.Map<IEnumerable<Despesa>>(despesas)
    //     );


    //    bool excedeuEssencial = resumo.Categorias.First(x => x.TipoCategoria == TipoCategoriaEnum.Essencial).ExcedeuLimite;

    //    bool excedeuNaoEssencial = resumo.Categorias.First(x => x.TipoCategoria == TipoCategoriaEnum.NaoEssencial).ExcedeuLimite;

    //    bool excedeuInvestimento = resumo.Categorias.First(x => x.TipoCategoria == TipoCategoriaEnum.Investimento).ExcedeuLimite;


    //    if (excedeuEssencial || excedeuNaoEssencial || excedeuInvestimento)
    //    {
    //        //emitir notificacao
    //    }

        throw new NotImplementedException();
    }
}
