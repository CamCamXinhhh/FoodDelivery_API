using AutoMapper;
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
        private readonly IFavouriteService _favouriteService;
        private readonly IMapper _mapper;


        public ProductService(DataContext dataContext, IMapper mapper, IFavouriteService favouriteService)
        {
            _dataContext = dataContext;
            _favouriteService = favouriteService;
            _mapper = mapper;
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            await _dataContext.Products.AddAsync(product);

            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<GetProductResponse> GetProductByIdAsync(int productId, string email)
        {
            Product product = await _dataContext.Products
                 .AsNoTracking()
                 .SingleOrDefaultAsync(p => p.ProductId == productId);

            GetProductResponse response = _mapper.Map<GetProductResponse>(product);
            response.IsFavourite = await _favouriteService.IsProductFavourite(email, productId);

            return response;
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
