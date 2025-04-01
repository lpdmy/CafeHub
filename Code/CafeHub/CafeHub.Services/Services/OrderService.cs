using CafeHub.Commons.Models;
using CafeHub.Repository.Interfaces;
using CafeHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            order.OrderDate = DateTime.UtcNow;
            order.Status = "Pending";
            order.StartDate = DateTime.UtcNow;
            

            await _orderRepository.AddAsync(order);
            return order;
        }

       
        public async Task<Order?> GetOrderDetailsAsync(int id)
        {
            return await _orderRepository.GetOrderWithDetailsAsync(id);
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerAsync(string customerId)
        {
            return await _orderRepository.GetOrdersByCustomerAsync(customerId);
        }
        public async Task<Order> UpdateOrderAsync(Order order)
        {
          

            // Update order properties
            await _orderRepository.UpdateAsync(order);

            return order;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<List<Order>> GetPendingOrdersAsync()
        {
            return await _orderRepository.GetPendingOrdersAsync();
        }
    }
}
