using System;

namespace EventTicket.Services.Ordering.Messages
{
    public class OrderPaymentUpdateMessage
    {
        public Guid OrderId { get; set; }
        public bool PaymentSuccess { get; set; }
    }
}
