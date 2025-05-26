using CadastroDespesa.Dominio.Worker.Producer.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.Worker.Producer
{
    public class RabbitProducer : IRabbitProducer
    {
        private readonly IServiceScopeFactory _connectionFactory;
        private readonly IConfiguration _configuration;
        private IConnection? _connection;
        private IChannel? _channel;

        public RabbitProducer(IConfiguration configuration, IServiceScopeFactory scopeFactory)
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

        public async Task DispararFilaPersistenciaDespesaConcluida(string mensagem, CancellationToken cancellationToken)
        {
            try
            {
                await AbrirConexao();

                string fila = "persistencia-financeiro";

                await _channel.QueueDeclareAsync(queue: fila, durable: true, exclusive: false, autoDelete: false, arguments: null);
                var body = Encoding.UTF8.GetBytes(mensagem);
                await _channel.BasicPublishAsync(exchange: "", routingKey: fila, body: body, cancellationToken);

                Console.WriteLine($"Mensagem publicada na fila '{fila}'.");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
