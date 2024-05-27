using GutoShopping.Email.Messages;

namespace GutoShopping.Email.Repository
{
    public interface IEmailRepository
    {
        Task LogEmail(UpdatePaymentResultMessage message);
    }
}
