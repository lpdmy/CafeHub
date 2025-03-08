using CafeHub.Commons.Models;
using CafeHub.DAO;
using CafeHub.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Repository.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await OrderDAO.Instance.GetAllOrdersAsync();
        }
        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await OrderDAO.Instance.GetOrderByIdAsync(id);
        }
        public async Task<Order> CreateOrderAsync(Order order)
        {
            return await OrderDAO.Instance.CreateOrderAsync(order);
        }
        public async Task<Order> UpdateOrderAsync(Order order)
        {
            return await OrderDAO.Instance.UpdateOrderAsync(order);
        }
        public async Task<Order> DeleteOrderAsync(int id)
        {
            return await OrderDAO.Instance.DeleteOrderAsync(id);
        }
    }
}
