using System;
using System.Collections.Generic;

namespace EventTicket.Services.Ordering.Messages
{
    public class BasketCheckoutMessage : IntegrationBaseMessage
    {
        public Guid BasketId { get; set; }
        public Guid UserId { get; set; }
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public string CardExpiration { get; set; }
        public int BasketTotal { get; set; }
    }
}
