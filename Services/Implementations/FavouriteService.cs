using FoodDelivery.Database;
using FoodDelivery.Database.Entities;
using FoodDelivery.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Services.Implementations
{
    public class FavouriteService : IFavouriteService
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<User> _userManager;

        public FavouriteService(DataContext dataContext, UserManager<User> userManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
        }

        public async Task<bool> CreateFavouriteAsync(string email, int productId)
        {
            var favourite = new Favourite()
            {
                UserId = await GetUserIdByUserEmail(email),
                ProductId = productId
            };

            await _dataContext.Favourites.AddAsync(favourite);

            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> IsProductFavourite(string email, int productId)
        {
            string userId = await GetUserIdByUserEmail(email);

            var favourite = await _dataContext.Favourites
                .SingleOrDefaultAsync(f => f.ProductId == productId && f.UserId == userId);

            if (favourite == null)
                return false;

            return true;
        }

        public async Task<bool> RemoveFavouriteAsync(string email, int productId)
        {
            var userId = await GetUserIdByUserEmail(email);
            
            var favourite = await _dataContext.Favourites
                .FirstOrDefaultAsync(f => f.ProductId == productId && f.UserId == userId);

            _dataContext.Favourites.Remove(favourite);

            return await _dataContext.SaveChangesAsync() > 0;
        }

        private async Task<string> GetUserIdByUserEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user.Id;
        }
    }
}
