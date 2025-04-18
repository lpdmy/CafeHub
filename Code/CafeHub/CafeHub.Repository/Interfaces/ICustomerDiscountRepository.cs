﻿using CafeHub.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Repository.Interfaces
{
    public interface ICustomerDiscountRepository : IGenericRepository<CustomerDiscount>
    {
        Task<CustomerDiscount?> GetLatestActiveDiscountByCustomerIdAsync(string customerId);
    }
}
