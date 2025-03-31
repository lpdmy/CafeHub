using CafeHub.Commons;
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
    public class DiscountRepository : GenericRepository<Discount>, IDiscountRepository
    {
        public DiscountRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<Discount?> GetDiscountByIdAsync(int discountId)
        {
            return await GetByIdAsync(discountId); // Using GenericRepository
        }
       
        public async Task<IEnumerable<Discount>> GetAllDiscountsAsync()
        {
            return await GetAllAsync(); // Using GenericRepository
        }

        public async Task<IEnumerable<Discount>> GetDiscountsByConditionAsync(string condition)
        {
            return await FindAsync(d => d.IsActive && d.Condition == condition); // Using GenericRepository
        }

        public async Task<IEnumerable<Discount>> GetActiveDiscountsAsync()
        {
            return await FindAsync(d => d.IsActive && d.StartDate <= DateTime.Now && d.EndDate >= DateTime.Now);
        }

        public async Task<IEnumerable<Discount>> GetDiscountsByTypeAsync(string type)
        {
            return await FindAsync(d => d.DiscountType == type && d.IsActive);
        }

        public async Task<bool> IsDiscountValidAsync(int discountId)
        {
            var discount = await GetByIdAsync(discountId);
            return discount != null && discount.IsActive && discount.StartDate <= DateTime.Now && discount.EndDate >= DateTime.Now;
        }
        public async Task AddDiscountAsync(Discount discount)
        {
            await AddAsync(discount);
        }

        public async Task UpdateDiscountAsync(Discount discount)
        {
            await UpdateAsync(discount);
        }

        public async Task RemoveDiscountAsync(int discountId)
        {
            var discount = await GetByIdAsync(discountId);
            if (discount != null)
            {
                await RemoveAsync(discount);
            }
        }

        // Get available discounts based on customer's membership type
        public async Task<List<Discount>> GetDiscountsByMembershipTypeAsync(string membershipType)
        {
            return await _context.Discounts
                .Where(d => d.IsActive
                            && d.StartDate <= DateTime.Now
                            && d.EndDate >= DateTime.Now
                            && d.Condition.Contains(membershipType))
                .ToListAsync();
        }

        // Assign a discount to a specific customer
        public async Task ApplyDiscountForCustomerAsync(string customerId, int discountId)
        {
            var discount = await _context.Discounts.FindAsync(discountId);
            if (discount == null || !discount.IsActive) return;

            var customerDiscount = new CustomerDiscount
            {
                CustomerId = customerId,
                DiscountId = discountId,
                DateGranted = DateTime.Now,
                IsActive = true
            };

            _context.CustomerDiscounts.Add(customerDiscount);
            await _context.SaveChangesAsync();
        }
    }
}
