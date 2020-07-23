using FoodDelivery.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Services.Interfaces
{
    public interface IFavouriteService
    {
        Task<bool> CreateFavouriteAsync(string email, int productId);
        Task<bool> RemoveFavouriteAsync(string email, int productId);
        Task<bool> IsProductFavourite(string email, int productId);
        Task<List<GetProductResponse>> GetFavouriteProductsOfUser(string email);
    }
}
