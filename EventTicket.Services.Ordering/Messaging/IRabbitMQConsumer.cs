namespace EventTicket.Services.Ordering.Messaging
{
    public interface IRabbitMQConsumer
    {
        void Start();
        void Stop();
        Task ReadMessgaes();
    }
}