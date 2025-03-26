using CafeHub.Commons.Models;
using CafeHub.Repository.Interfaces;
using CafeHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // Lấy tất cả các danh mục
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();  
        }

        // Lấy danh mục theo ID
        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id); 
        }

        // Tạo mới danh mục
        public async Task CreateCategoryAsync(Category category)
        {
            await _categoryRepository.AddAsync(category);  
        }

        // Cập nhật danh mục
        public async Task UpdateCategoryAsync(Category category)
        {
            await _categoryRepository.UpdateAsync(category);  
        }

        // Xóa danh mục
        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category != null)
            {
                await _categoryRepository.RemoveAsync(category);  
            }
        }

        // Tìm kiếm danh mục theo tên
        public async Task<IEnumerable<Category>> GetCategoriesByNameAsync(string name)
        {
            return await _categoryRepository.GetCategoriesByNameAsync(name);
        }
    }
}
