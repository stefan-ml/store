using System.Text;
using EventTicket.Services.Ordering.Entities;
using EventTicket.Services.Ordering.Messages;
using EventTicket.Services.Ordering.Repositories;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace EventTicket.Services.Ordering.Messaging
{
    public class RabbitMQConsumer : IRabbitMQConsumer
    {
        private readonly string checkoutMessageQueue = "eventticketorder";
        private readonly string orderPaymentUpdatedMessageQueue = "orderPaymentUpdated";

        private readonly IConfiguration _configuration;

        private readonly OrderRepository _orderRepository;
        private readonly IMessageBus _messageBus;

        public RabbitMQConsumer(IConfiguration configuration, IMessageBus messageBus, OrderRepository orderRepository)
        {
            _configuration = configuration;
            _orderRepository = orderRepository;
            _messageBus = messageBus;

        }

        public void Start()
        {
            ConnectionFactory factory = new ConnectionFactory() { HostName = "rabbitmq", Port = 5672, UserName = "guest", Password = "guest" };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                try
                {
                    channel.ExchangeDeclare("checkoutmessage", ExchangeType.Topic);
                }
                catch (Exception)
                {
                }

                channel.QueueDeclare(queue: checkoutMessageQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);
                channel.QueueDeclare(queue: orderPaymentUpdatedMessageQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);
                channel.QueueBind(queue: checkoutMessageQueue, exchange: "checkoutmessage", routingKey: "eventticketorder");


                var checkoutConsumer = new EventingBasicConsumer(channel);
                checkoutConsumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    OnCheckoutMessageReceived(message);

                    channel.BasicAck(ea.DeliveryTag, false);
                };

                var orderPaymentUpdateConsumer = new EventingBasicConsumer(channel);
                orderPaymentUpdateConsumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    OnOrderPaymentUpdateReceived(message);

                    channel.BasicAck(ea.DeliveryTag, false);
                };

                channel.BasicConsume(queue: checkoutMessageQueue, autoAck: false, consumer: checkoutConsumer);
                channel.BasicConsume(queue: orderPaymentUpdatedMessageQueue, autoAck: false, consumer: orderPaymentUpdateConsumer);

                Console.WriteLine("RabbitMQ Consumer Started");
                Console.ReadLine(); // Keep the application running
            }
        }

        private void OnOrderPaymentUpdateReceived(string message)
        {
            OrderPaymentUpdateMessage orderPaymentUpdateMessage =
                JsonConvert.DeserializeObject<OrderPaymentUpdateMessage>(message);

            _orderRepository.UpdateOrderPaymentStatus(orderPaymentUpdateMessage.OrderId, orderPaymentUpdateMessage.PaymentSuccess);
        }

        private void OnCheckoutMessageReceived(string message)
        {
            BasketCheckoutMessage basketCheckoutMessage = JsonConvert.DeserializeObject<BasketCheckoutMessage>(message);

            Guid orderId = Guid.NewGuid();

            Order order = new Order
            {
                UserId = basketCheckoutMessage.UserId,
                Id = orderId,
                OrderPaid = false,
                BasketId = basketCheckoutMessage.BasketId,
                OrderPlaced = DateTime.Now,
                OrderTotal = basketCheckoutMessage.BasketTotal
            };

            _orderRepository.AddOrder(order);

            OrderPaymentRequestMessage orderPaymentRequestMessage = new OrderPaymentRequestMessage
            {
                CardExpiration = basketCheckoutMessage.CardExpiration,
                CardName = basketCheckoutMessage.CardName,
                CardNumber = basketCheckoutMessage.CardNumber,
                OrderId = orderId,
                Total = basketCheckoutMessage.BasketTotal
            };

            try
            {
                _messageBus.PublishMessage(orderPaymentRequestMessage, orderPaymentUpdatedMessageQueue);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Stop()
        {
        }
    }
}
