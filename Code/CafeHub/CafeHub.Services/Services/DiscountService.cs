using CafeHub.Commons.Models;
using CafeHub.Repository.Interfaces;
using CafeHub.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CafeHub.Service.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountService(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
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
    }
}
