using CafeHub.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Services.Interfaces
{
    public interface IPaymentService
    {
        Task CreatePaymentAsync(Payment payment);
        Task<Payment?> GetPaymentByOrderIdAsync(int orderId);
        Task<IEnumerable<Payment>> GetPaymentsByCustomerIdAsync(string customerId);
    }
}
