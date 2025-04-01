using CafeHub.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Repository.Interfaces
{
    public interface IOrderItemRepository : IGenericRepository<OrderItem>
    {
        Task<List<OrderItem>> GetCartItemsByUserIdAsync(string userId);
        Task<OrderItem> GetByOrderIdAndProductIdAsync(int orderId, int productId);
        Task<OrderItem?> GetByOrderIdAndOptionsAsync(int orderId, int productId, string size, int sugarAmount, int iceAmount);

    }
}
