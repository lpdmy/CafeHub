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
    public class CustomerDiscountRepository : GenericRepository<CustomerDiscount>, ICustomerDiscountRepository
    {
        public CustomerDiscountRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<CustomerDiscount?> GetLatestActiveDiscountByCustomerIdAsync(string customerId)
        {
            return await _context.CustomerDiscounts
                .Include(cd => cd.Discount) // Ensure Discount details are loaded
                .Where(cd => cd.CustomerId == customerId && cd.IsActive)
                .OrderByDescending(cd => cd.DateGranted)
                .FirstOrDefaultAsync();
        }
    }
}
