using CafeHub.Commons;
using CafeHub.Commons.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.DAO
{
    public class OrderDAO : SingletonBase<OrderDAO>
    {
        private ApplicationDbContext _context;

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            _context = new();
            return await _context.Orders
                .Include(o => o.Customer)
                .ToListAsync();
        }
        public async Task<Order> GetOrderByIdAsync(int id)
        {
            _context = new();
            var OrderByID = await _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(o => o.Id == id);
            if (OrderByID == null) { return null; }
            return OrderByID;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            _context = new();
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
        public async Task<Order> UpdateOrderAsync(Order order)
        {
            _context = new();
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }
        public async Task<Order> DeleteOrderAsync(int id)
        {
            _context = new();
            var OrderToDelete = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == id);
            if (OrderToDelete == null) { return null; }
            _context.Orders.Remove(OrderToDelete);
            await _context.SaveChangesAsync();
            return OrderToDelete;
        }
    }
}
