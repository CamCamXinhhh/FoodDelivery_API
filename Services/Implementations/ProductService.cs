using FoodDelivery.Database;
using FoodDelivery.Database.Entities;
using FoodDelivery.DTOs.Responses;
using FoodDelivery.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dataContext;

        public ProductService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            await _dataContext.Products.AddAsync(product);

            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _dataContext.Products
                 .AsNoTracking()
                 .SingleOrDefaultAsync(p => p.ProductId == productId);
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _dataContext.Products.AsNoTracking().ToListAsync();
        }

        public async Task<GetProductsByNameResponse> GetProductsByNameAsync(string productName)
        {

            //Get list of products by name
            var searchedProducts = await _dataContext.Products
                .AsNoTracking()
                .Where(p => p.ProductName.Contains(productName))
                .ToListAsync();

            var result = new GetProductsByNameResponse()
            {
                Foods = searchedProducts,
                Count = searchedProducts.Count
            };

            return result;
        }
    }
}
