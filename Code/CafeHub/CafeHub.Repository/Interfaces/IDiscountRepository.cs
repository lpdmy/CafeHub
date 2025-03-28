using CafeHub.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Repository.Interfaces
{
    public interface IDiscountRepository : IGenericRepository<Discount>
    {
        Task<IEnumerable<Discount>> GetActiveDiscountsAsync();
        Task<IEnumerable<Discount>> GetDiscountsByTypeAsync(string type);
        Task<IEnumerable<Discount>> GetDiscountsByConditionAsync(string condition);
        Task<bool> IsDiscountValidAsync(int discountId);
        Task<Discount?> GetDiscountByIdAsync(int discountId);
        Task<IEnumerable<Discount>> GetAllDiscountsAsync();
        Task AddDiscountAsync(Discount discount);
        Task UpdateDiscountAsync(Discount discount);
        Task RemoveDiscountAsync(int discountId);
    }
}
