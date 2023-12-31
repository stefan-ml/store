using System.Threading.Tasks;

namespace EventTicket.Services.ShoppingBasket.Messages
{
    public interface IMessageBus
    {
        Task PublishMessage (IntegrationBaseMessage message, string topicName);
    }
}
