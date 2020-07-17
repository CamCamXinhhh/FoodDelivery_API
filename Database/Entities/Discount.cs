using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FoodDelivery.Database.Entities
{
    public class Discount
    {
        [JsonIgnore]
        public int DiscountId { get; set; }
        public string DiscountCode { get; set; }
        public double DiscountPercentages { get; set; }
    }
}
