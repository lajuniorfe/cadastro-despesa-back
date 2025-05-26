using CadastroDespesa.Dominio.Worker.Consumer.Interface;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.Worker.Consumer
{
    public class QueueConsumerWorker: BackgroundService
    {
        private readonly IRabbitConsumer rabbitConsumer;

        public QueueConsumerWorker(IRabbitConsumer rabbitConsumer)
        {
            this.rabbitConsumer = rabbitConsumer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await rabbitConsumer.OuvirFilaPersistenciaDespesa(stoppingToken);
        }
    }
}
