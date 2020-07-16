using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FoodDelivery.Constants;
using FoodDelivery.DTOs.Responses;
using FoodDelivery.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        [HttpGet(ApiRoutes.Category.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetCategoriesAsync();

            return Ok(categories);
        }

        /// <summary>
        /// Get a category by categoryId
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet(ApiRoutes.Category.Get)]
        public async Task<IActionResult> Get([FromRoute] int categoryId)
        {
            var category = await _categoryService.GetCategoryByIdAsync(categoryId);

            if (category == null)
                return NotFound();

            return Ok(_mapper.Map<GetCategoryResponse>(category));
        }

        [HttpGet(ApiRoutes.Category.GetListFoodOfACategory)]
        public async Task<IActionResult> GetFoodsOfACategory([FromRoute]int categoryId)
        {
            var foodsOfACateogry = await _categoryService.GetAllProductsOfACategory(categoryId);

            if (foodsOfACateogry == null)
                return NotFound();
            return Ok(foodsOfACateogry);
        }
    }
}