namespace Customer.Api.Application.Interfaces.Messaging
{
    public interface IMessagePublisher
    {
        void Publish<T>(T message);
    }
}
