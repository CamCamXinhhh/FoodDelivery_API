using FoodDelivery.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int categoryId);
        Task<bool> CreateCategoryAsync(Category category);
        Task<List<Product>> GetAllProductsOfACategory(int categoryId);
    }
}
