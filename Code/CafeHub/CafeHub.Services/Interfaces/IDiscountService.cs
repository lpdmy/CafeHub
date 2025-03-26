using CafeHub.Commons.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CafeHub.Service.Interfaces
{
    public interface IDiscountService
    {
        Task<Discount?> GetDiscountByIdAsync(int discountId);
        Task<IEnumerable<Discount>> GetAllDiscountsAsync();
        Task<IEnumerable<Discount>> GetDiscountsByConditionAsync(string condition);
        Task<IEnumerable<Discount>> GetActiveDiscountsAsync();
        Task<IEnumerable<Discount>> GetDiscountsByTypeAsync(string type);
        Task<bool> IsDiscountValidAsync(int discountId);
        Task AddDiscountAsync(Discount discount);
        Task UpdateDiscountAsync(Discount discount);
        Task RemoveDiscountAsync(int discountId);
    }
}
