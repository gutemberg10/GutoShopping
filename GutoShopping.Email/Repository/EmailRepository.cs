using GutoShopping.Email.Messages;
using GutoShopping.Email.Model;
using GutoShopping.Email.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GutoShopping.Email.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly DbContextOptions<ProductContext> _context;

        public EmailRepository(DbContextOptions<ProductContext> context)
        {
            _context = context;
        }

        public async Task LogEmail(UpdatePaymentResultMessage message)
        {
            EmailLog email = new EmailLog()
            {
                Email = message.Email,
                SentDate = DateTime.Now,
                Log = $"Order - {message.OrderId} has been created successfully!"
            };
            await using var _db = new ProductContext(_context);
            _db.Emails.Add(email);
            await _db.SaveChangesAsync();
        }
       
    }
}
