using CafeHub.Commons.Models;
using System.Collections.Generic;

namespace CafeHub.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
    }
}
