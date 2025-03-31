using CafeHub.Commons.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Services.Interfaces
{
    public interface IVnPayService
    {
        Task<string> GetPaymentUrl(int orderId);
        Task<string> ProcessPaymentResponse(IQueryCollection queryCollection); 
    }



}
