using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Servicos.Interfaces;
using CadastroDespesa.Dominio.Worker.Consumer.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace CadastroDespesa.Dominio.Worker.Consumer
{
    public class RabbitConsumer : IRabbitConsumer
    {
        private readonly IServiceScopeFactory _connectionFactory;
        private readonly IConfiguration _configuration;
        private IConnection? _connection;
        private IChannel? _channel;
        private readonly IDespesaServico despesaServico;

        public RabbitConsumer(IConfiguration configuration, IServiceScopeFactory scopeFactory )
        {
            _configuration = configuration;
            _connectionFactory = scopeFactory;

        

        }

        private async Task AbrirConexao()
        {
            if (_connection == null || !_connection.IsOpen)
            {
                var connectionFactory = new ConnectionFactory()
                {
                    HostName = _configuration["RabbitMQ:Host"],
                    Port = int.Parse(_configuration["RabbitMQ:Port"] ?? "5672"),
                    UserName = _configuration["RabbitMQ:Username"],
                    Password = _configuration["RabbitMQ:Password"]
                };

                _connection = await connectionFactory.CreateConnectionAsync();
            }

            if (_channel == null || !_channel.IsOpen)
            {
                _channel = await _connection.CreateChannelAsync();
            }
        }

        public async Task OuvirFilaPersistenciaDespesa(CancellationToken cancellationToken)
        {
            await AbrirConexao();

            string queueName = "persistencia-dados-planilha";

            await _channel
                .QueueDeclareAsync(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                DespesaPersistencia despesaRecebida = JsonSerializer.Deserialize<DespesaPersistencia>(message);

                using var scope = _connectionFactory.CreateScope();
                var despesaServico = scope.ServiceProvider.GetRequiredService<IDespesaServico>();

                await despesaServico.PersistirDespesas(despesaRecebida, cancellationToken);

                await _channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
            };

            await _channel.BasicConsumeAsync(queue: queueName, autoAck: false, consumer: consumer);

        }
    }
}
