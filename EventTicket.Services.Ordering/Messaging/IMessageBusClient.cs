using EventTicket.Services.Ordering.Messages;
using System.Threading.Tasks;

namespace EventTicket.Services.Ordering.Messaging
{
    public interface IMessageBusClient
    {
        void PublishPaymentRequest(IntegrationBaseMessage paymentRequest);
    }
}
