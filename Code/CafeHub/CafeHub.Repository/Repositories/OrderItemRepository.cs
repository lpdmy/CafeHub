using CafeHub.Commons;
using CafeHub.Commons.Models;
using CafeHub.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Repository.Repositories
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<List<OrderItem>> GetCartItemsByUserIdAsync(string userId)
        {
            var cartItems = await _context.OrderItems
                .Include(x => x.Product)
                .Where(x => x.Order != null
                    && x.Order.CustomerId == userId
                    && x.Order.Status == "Draft")
                .ToListAsync();

            return cartItems;
        }

    }
}
