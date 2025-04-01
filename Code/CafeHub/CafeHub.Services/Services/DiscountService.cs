using CafeHub.Commons.Models;
using CafeHub.Repository.Interfaces;
using CafeHub.Repository.Repositories;
using CafeHub.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CafeHub.Service.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly ICustomerDiscountRepository _customerDiscountRepository;

        public DiscountService(IDiscountRepository discountRepository, ICustomerDiscountRepository customerDiscountRepository)
        {
            _discountRepository = discountRepository;
            _customerDiscountRepository = customerDiscountRepository;
           
        }

        public async Task<Discount?> GetDiscountByIdAsync(int discountId)
        {
            return await _discountRepository.GetDiscountByIdAsync(discountId);
        }

        public async Task<IEnumerable<Discount>> GetAllDiscountsAsync()
        {
            return await _discountRepository.GetAllDiscountsAsync();
        }

        public async Task<IEnumerable<Discount>> GetDiscountsByConditionAsync(string condition)
        {
            return await _discountRepository.GetDiscountsByConditionAsync(condition);
        }

        public async Task<IEnumerable<Discount>> GetActiveDiscountsAsync()
        {
            return await _discountRepository.GetActiveDiscountsAsync();
        }

        public async Task<IEnumerable<Discount>> GetDiscountsByTypeAsync(string type)
        {
            return await _discountRepository.GetDiscountsByTypeAsync(type);
        }

        public async Task<bool> IsDiscountValidAsync(int discountId)
        {
            return await _discountRepository.IsDiscountValidAsync(discountId);
        }

        public async Task AddDiscountAsync(Discount discount)
        {
            await _discountRepository.AddDiscountAsync(discount);
        }

        public async Task UpdateDiscountAsync(Discount discount)
        {
            await _discountRepository.UpdateDiscountAsync(discount);
        }

        public async Task RemoveDiscountAsync(int discountId)
        {
            await _discountRepository.RemoveDiscountAsync(discountId);
        }

        public async Task<List<Discount>> GetDiscountsByMembershipTypeAsync(string membershipType)
        {
            return await _discountRepository.GetDiscountsByMembershipTypeAsync(membershipType);
        }

        public async Task ApplyDiscountForCustomerAsync(string customerId, int discountId)
        {
            await _discountRepository.ApplyDiscountForCustomerAsync(customerId, discountId);
        }
        public async Task<CustomerDiscount?> GetDiscountByCustomerIdAsync(string customerId)
        {
            return await _customerDiscountRepository.GetLatestActiveDiscountByCustomerIdAsync(customerId);
        }
    }
}
