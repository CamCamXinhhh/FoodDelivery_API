using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Constants
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Identity
        {
            public const string Login = Base + "/identity/login";
            public const string Register = Base + "/identity/register";
            public const string Refresh = Base + "/identity/refresh";
        }

        public static class Product
        {
            public const string GetAll = Base + "/products";
            public const string Get = Base + "/products/{email}/{productId}";
            public const string Create = Base + "/products";
            public const string GetByName = Base + "/products/search/{productName}";
        }

        public static class Category
        {
            public const string GetAll = Base + "/categories";
            public const string Get = Base + "/categories/{categoryId}";
            public const string Create = Base + "/categories";
            public const string GetListFoodOfACategory = Base + "/categories/{categoryId}/products";
        }

        public static class Discount
        {
            public const string Get = Base + "/discounts/{discountCode}";
        }

        public static class User
        {
            public const string Get = Base + "/users/{email}";
        }

        public static class Favourite
        {
            public const string Create = Base + "/favourites";
            public const string Delete = Base + "/favourites/{email}/{productId}";
            
        }
    }
}
