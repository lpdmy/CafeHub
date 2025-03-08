using CafeHub.Commons.Models;
using CafeHub.Repository.Interfaces;
using CafeHub.Repository.Repositories;
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
        private readonly IOrderRepository _iorderRepository;
        public OrderService()
        {
            _iorderRepository = new OrderRepository();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _iorderRepository.GetAllOrdersAsync();
        }
        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _iorderRepository.GetOrderByIdAsync(id);
        }
        public async Task<Order> CreateOrderAsync(Order order)
        {
            return await _iorderRepository.CreateOrderAsync(order);
        }
        public async Task<Order> UpdateOrderAsync(Order order)
        {
            return await _iorderRepository.UpdateOrderAsync(order);
        }
        public async Task<Order> DeleteOrderAsync(int id)
        {
            return await _iorderRepository.DeleteOrderAsync(id);
        }
    }
}
