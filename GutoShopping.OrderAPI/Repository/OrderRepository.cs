using GutoShopping.OrderAPI.Model;
using GutoShopping.OrderAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GutoShopping.OrderAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContextOptions<ProductContext> _context;

        public OrderRepository(DbContextOptions<ProductContext> context)
        {
            _context = context;
        }

        public async Task<bool> AddOrder(OrderHeader header)
        {
            if (header == null) return false;
            await using var _db = new ProductContext(_context);
            _db.Headers.Add(header);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task UpdateOrderPaymentStatus(long orderHeaderId, bool status)
        {
            await using var _db = new ProductContext(_context);
            var header = await _db.Headers.FirstOrDefaultAsync(o => o.Id == orderHeaderId);
            if (header != null)
            {
                header.PaymentStatus = status;
                await _db.SaveChangesAsync();
            }
        }
       
    }
}
