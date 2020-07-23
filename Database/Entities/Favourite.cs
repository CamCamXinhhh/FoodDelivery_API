using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Database.Entities
{
    public class Favourite
    {
        public int FavouriteId { get; set; }

        //Relationship
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

    }
}
