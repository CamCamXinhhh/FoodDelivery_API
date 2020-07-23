using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FoodDelivery.Database.Entities
{
    public class User : IdentityUser
    {
        public string Address { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string UserImage { get; set; }

        //Relationship
        [JsonIgnore]
        public List<Favourite> Favourites { get; set; }

    }
}
