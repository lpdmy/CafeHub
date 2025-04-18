﻿using CafeHub.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Repository.Interfaces
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task<Payment?> GetPaymentByOrderIdAsync(int orderId);
        Task<IEnumerable<Payment>> GetPaymentsByCustomerIdAsync(string customerId);
    }
}
