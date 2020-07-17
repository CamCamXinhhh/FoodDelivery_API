using FoodDelivery.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Services.Interfaces
{
    public interface IDiscountService
    {
        Task<Discount> GetDiscountByDiscountCode(string discountCode);
    }
}
