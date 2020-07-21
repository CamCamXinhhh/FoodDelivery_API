using FoodDelivery.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.DTOs.Responses
{
    public class GetProductsByNameResponse
    {
        public IEnumerable<Product> Foods { get; set; }
        public int Count { get; set; }
    }
}
