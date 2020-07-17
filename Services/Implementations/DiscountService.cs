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
    public class DiscountService : IDiscountService
    {
        private readonly DataContext _dataContext;

        public DiscountService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Discount> GetDiscountByDiscountCode(string discountCode)
        {
            return await _dataContext.Discounts
                .SingleOrDefaultAsync(dis => discountCode.ToUpper() == dis.DiscountCode);
        }
    }
}
