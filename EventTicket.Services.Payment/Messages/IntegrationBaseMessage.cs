using System;

namespace EventTicket.Services.Payment.Messages
{
    public class IntegrationBaseMessage
    {
        public Guid Id { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
