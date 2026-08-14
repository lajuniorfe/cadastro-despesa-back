using CadastroDespesa.DTO.Notifications.Requests;
using System.Threading.Channels;
namespace CadastroDespesa.Application.Notifications.Interfaces;

public interface INotificationServices
{
    ChannelReader<NotificationMessageRequest> Subscribe(CancellationToken ct);

    Task NotifyAsync(NotificationMessageRequest message, CancellationToken ct = default);

    Task SendConnectedMessage(CancellationToken ct);

    Task<NotificationMessageRequest> NotificarGastoAcimaLimite(CancellationToken ct = default);
}
