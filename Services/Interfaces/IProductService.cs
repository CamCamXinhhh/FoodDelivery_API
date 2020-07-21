using FoodDelivery.Database.Entities;
using FoodDelivery.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task<bool> CreateProductAsync(Product product);
        Task<GetProductsByNameResponse> GetProductsByNameAsync(string productName);

    }
}
