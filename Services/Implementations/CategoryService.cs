using FoodDelivery.Database;
using FoodDelivery.Database.Entities;
using FoodDelivery.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _dataContext;

        public CategoryService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            await _dataContext.Categories.AddAsync(category);

            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<List<Product>> GetAllProductsOfACategory(int categoryId)
        {
            var category = await GetCategoryByIdAsync(categoryId);

            if(category != null)
            {
                return category.Products;
            }

            return null;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _dataContext.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            return await _dataContext.Categories
                 .SingleOrDefaultAsync(c => c.CategoryId == categoryId);
        }
    }
}
