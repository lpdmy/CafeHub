using CafeHub.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CafeHub.Repository.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Category>> GetCategoriesByNameAsync(string name);
    }
}
