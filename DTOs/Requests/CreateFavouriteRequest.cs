using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.DTOs.Requests
{
    public class CreateFavouriteRequest
    {
        public int ProductId { get; set; }
        public string Email { get; set; }
    }
}
