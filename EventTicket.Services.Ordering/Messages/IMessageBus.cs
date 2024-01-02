using System.Threading.Tasks;

namespace EventTicket.Services.Ordering.Messages
{
    public interface IMessageBus
    {
        void PublishMessage (IntegrationBaseMessage message, string exchangeName);
    }
}
