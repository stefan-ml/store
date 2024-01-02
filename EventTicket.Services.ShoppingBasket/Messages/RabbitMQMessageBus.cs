using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Connections;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace EventTicket.Services.ShoppingBasket.Messages
{
    public class RabbitMQMessageBus : IMessageBus
    {
        public void PublishMessage(IntegrationBaseMessage message, string exchangeName, string routingKey)
        {
            ConnectionFactory factory = new ConnectionFactory()
            {
                HostName = "rabbitmq",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };
            factory.ClientProvidedName = "Rabbit Sender App";

            using (IConnection cnn = factory.CreateConnection())
            using (IModel channel = cnn.CreateModel())
            {
                // Declare the exchange
                channel.ExchangeDeclare(exchangeName, ExchangeType.Topic);

                // Serialize the message
                var jsonMessage = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(jsonMessage);

                // Publish the message to the exchange with the specified routing key
                channel.BasicPublish(exchange: exchangeName, routingKey: routingKey, basicProperties: null, body: body);

                Console.WriteLine($"Sent message to exchange: {exchangeName}, routing key: {routingKey}");
            }
        }
    }
}
