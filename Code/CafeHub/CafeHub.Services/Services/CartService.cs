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
    public class CartService : ICartService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IAccountService _accountService;

        public CartService(IOrderItemRepository orderItemRepository, IOrderRepository orderRepository, IAccountService accountService)
        {
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
            _accountService = accountService;
        }

        public async Task<List<OrderItem>> GetCartItemsByUserIdAsync(string userId)
        {
            return await _orderItemRepository.GetCartItemsByUserIdAsync(userId);
        }

        public async Task AddToCartAsync(string customerId, OrderItem item)
        {
            var draftOrder = await _orderRepository.GetDraftOrderByCustomerIdAsync(customerId);
            if (draftOrder == null)
            {
                draftOrder = new Order
                {
                    CustomerId = customerId,
                    Status = "Draft",
                    OrderDate = DateTime.Now
                };
                await _orderRepository.AddAsync(draftOrder);
            }

            item.OrderId = draftOrder.Id;
            await _orderItemRepository.AddAsync(item);
        }


        public async Task ClearCartByUserIdAsync(string userId)
        {
            var draftOrder = await _orderRepository.GetDraftOrderByCustomerIdAsync(userId);
            if (draftOrder != null)
            {
                await _orderRepository.RemoveAsync(draftOrder);
            }
        }

    }
}
