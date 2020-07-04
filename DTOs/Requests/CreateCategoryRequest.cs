using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.DTOs.Requests
{
    public class CreateCategoryRequest
    {
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
    }
}
