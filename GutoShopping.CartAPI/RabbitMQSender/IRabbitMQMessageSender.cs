using GutoShopping.MessageBus;

namespace GutoShopping.CartAPI.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queueName);
    }
}
