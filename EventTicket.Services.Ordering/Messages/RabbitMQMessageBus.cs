using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace EventTicket.Services.Ordering.Messages
{
    public class RabbitMQMessageBus : IMessageBus
    {
        public void PublishMessage(IntegrationBaseMessage message, string exchangeName)
        {
            ConnectionFactory factory = new ConnectionFactory() { HostName = "rabbitmq", Port = 5672, UserName = "guest", Password = "guest" };
            factory.ClientProvidedName = "Rabbit Sender App";

            using (IConnection cnn = factory.CreateConnection())
            using (IModel channel = cnn.CreateModel())
            {
                // Declare the exchange
                channel.ExchangeDeclare(exchangeName, ExchangeType.Topic);

                // Serialize the message
                var jsonMessage = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(jsonMessage);

                // Publish the message to the exchange
                channel.BasicPublish(exchange: exchangeName, routingKey: "", basicProperties: null, body: body);

                Console.WriteLine($"Sent message to exchange: {exchangeName}");
            }
        }
    }
}
