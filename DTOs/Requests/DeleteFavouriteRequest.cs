using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.DTOs.Requests
{
    public class DeleteFavouriteRequest
    {
        public int ProductId { get; set; }
        public string Email { get; set; }
    }
}
