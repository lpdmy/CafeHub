﻿using CafeHub.Commons;
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
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<Order?> GetOrderWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(o => o.OrderItems) // Adjust navigation properties based on your model
                .ThenInclude(oi => oi.Product) // If you want product details too
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerAsync(string customerId)
        {
            return await _dbSet
                .Where(o => o.CustomerId == customerId)
                .Include(o => o.OrderItems) // Optional, if you want details
                .ToListAsync();
        }
        public async Task<Order> GetDraftOrderByCustomerIdAsync(string customerId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.CustomerId == customerId && o.Status == "Draft");
        }
    }
}
