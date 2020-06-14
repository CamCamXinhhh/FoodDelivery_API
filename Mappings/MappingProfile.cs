using AutoMapper;
using FoodDelivery.Database.Entities;
using FoodDelivery.DTOs.Requests;
using FoodDelivery.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FoodDelivery.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Product
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, GetProductResponse>();
            #endregion

            #region Category
            CreateMap<Category, GetCategoryResponse>();

            #endregion
        }
    }
}
