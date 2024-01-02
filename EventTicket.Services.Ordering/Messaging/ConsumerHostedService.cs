namespace EventTicket.Services.Ordering.Messaging
{
    public class ConsumerHostedService : BackgroundService
    {
        private readonly IRabbitMQConsumer _consumerService;

        public ConsumerHostedService(IRabbitMQConsumer consumerService)
        {
            _consumerService = consumerService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _consumerService.ReadMessgaes();

                // Add a delay or sleep between iterations to avoid tight loop
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken); // Adjust the delay as needed
            }
        }
    }
}
