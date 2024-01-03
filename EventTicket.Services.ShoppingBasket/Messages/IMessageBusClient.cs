using System.Threading.Tasks;

namespace EventTicket.Services.ShoppingBasket.Messages
{
    public interface IMessageBusClient
    {
        void PublishNewOrder(IntegrationBaseMessage order);
    }
}
