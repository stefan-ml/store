using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using EventTicket.Services.Ordering.Messaging;

namespace EventTicket.Services.Ordering
{
    public class Worker : BackgroundService
    {
        private readonly IRabbitMQConsumer _rabbitMQConsumer;
        public Worker(IRabbitMQConsumer rabbitMQConsumer)
        {
            _rabbitMQConsumer = rabbitMQConsumer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _rabbitMQConsumer.Start();

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
