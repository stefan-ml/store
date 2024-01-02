using System.Threading.Tasks;

namespace EventTicket.Services.ShoppingBasket.Messages
{
    public interface IMessageBus
    {
        void PublishMessage(IntegrationBaseMessage message, string exchangeName, string routingKey);
    }
}
