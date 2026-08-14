using CadastroDespesa.Application.Notifications.Interfaces;
using CadastroDespesa.DTO.Notifications.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CadastroDespesa.Api.Controller.Notifications
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationServices _notificationService;
        public NotificationsController(INotificationServices notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("stream")]
        public async Task Stream(CancellationToken ct)
        {
            Response.Headers.Append("Cache-Control", "no-cache");
            Response.Headers.Append("Content-Type", "text/event-stream");
            Response.Headers.Append("X-Accel-Buffering", "no");

            var reader = _notificationService.Subscribe(ct);

            await _notificationService.SendConnectedMessage(ct);

            await foreach (var message in reader.ReadAllAsync(ct))
            {
                var json = JsonSerializer.Serialize(message);

                await Response.WriteAsync($"data: {json}\n\n", ct);
                await Response.Body.FlushAsync(ct);
            }
        }

        [HttpPost("notify")]
        public async Task<IActionResult> Notify([FromBody] NotificationMessageRequest request, CancellationToken ct)
        {
            await _notificationService.NotifyAsync(request, ct);

            return Ok();
        }


    }
}
