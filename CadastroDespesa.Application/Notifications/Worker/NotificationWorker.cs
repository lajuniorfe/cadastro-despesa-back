using CadastroDespesa.Application.Notifications.Interfaces;
using CadastroDespesa.DTO.Notifications.Requests;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CadastroDespesa.Application.Notifications.Worker
{
    public class NotificationWorker : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public NotificationWorker(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();

                var notificationApp =
                    scope.ServiceProvider.GetRequiredService<INotificationServices>();

                var mensagem = await notificationApp.NotificarGastoAcimaLimite();

                await notificationApp.NotifyAsync(mensagem);

                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}
