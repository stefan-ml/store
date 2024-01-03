using EventTicket.Services.Payment.Messages;

namespace EventTicket.Services.Payment.Messaging
{
    public interface IMessageBusClient
    {
        void PublishPaymentResponse(OrderPaymentUpdateMessage paymentRequest);
    }
}
