using CafeHub.Commons;

using CafeHub.Commons.Models;
using CafeHub.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CafeHub.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
