using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Database.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string Detail { get; set; }
        public double Calories { get; set; }
        public double Price { get; set; }
        public string ProductImage { get; set; }
        public int TimeToMake { get; set; }

        //Relationship EF Core
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
