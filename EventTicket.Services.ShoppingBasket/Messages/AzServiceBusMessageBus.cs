namespace EventTicket.Services.ShoppingBasket.Messages
{
    public class AzServiceBusMessageBus: IMessageBus
    {
        //TODO: read from settings
        private string connectionString =
            "Endpoint=sb://eventticket-sample.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=d9OlPx9Jtvv8Ig6xvPyO5J78Th1wz4pnd+ASbCGqqpE=";

        public async Task PublishMessage(IntegrationBaseMessage message, string topicName)
        {
            //ISenderClient topicClient = new TopicClient(connectionString, topicName);

            //var jsonMessage = JsonConvert.SerializeObject(message);
            //var serviceBusMessage = new Message(Encoding.UTF8.GetBytes(jsonMessage))
            //{
            //    CorrelationId = Guid.NewGuid().ToString()
            //};

            //await topicClient.SendAsync(serviceBusMessage);
            //Console.WriteLine($"Sent message to {topicClient.Path}");
            //await topicClient.CloseAsync();

        }
    }
}
