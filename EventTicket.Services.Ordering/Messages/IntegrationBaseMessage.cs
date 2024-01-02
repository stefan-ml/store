using System;

namespace EventTicket.Services.Ordering.Messages
{
    public class IntegrationBaseMessage
    {
        public Guid Id { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
