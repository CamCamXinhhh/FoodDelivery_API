using FoodDelivery.Database.Entities;
using FoodDelivery.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> GetUserDetailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user;
        }
    }
}
