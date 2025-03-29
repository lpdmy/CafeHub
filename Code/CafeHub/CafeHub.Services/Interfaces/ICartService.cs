using CafeHub.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Services.Interfaces
{
    public interface ICartService
    {
        Task<List<OrderItem>> GetCartItemsByUserIdAsync(string userId);
        Task AddToCartAsync(string customerId, OrderItem item);

        Task ClearCartByUserIdAsync(string userId);
    }
}
