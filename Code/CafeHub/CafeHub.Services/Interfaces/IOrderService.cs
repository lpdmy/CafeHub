﻿using CafeHub.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<Order?> GetOrderDetailsAsync(int id);
        Task<IEnumerable<Order>> GetOrdersByCustomerAsync(string customerId);
    }
}
