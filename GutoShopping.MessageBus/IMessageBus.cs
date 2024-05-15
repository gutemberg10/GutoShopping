namespace GutoShopping.MessageBus
{
    public interface IMessageBus
    {
        Task PublicMessage(BaseMessage message, string queueName);
    }
}
