﻿using AutoMapper;
using FoodDelivery.Constants;
using FoodDelivery.Database.Entities;
using FoodDelivery.DTOs.Requests;
using FoodDelivery.DTOs.Responses;
using FoodDelivery.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodDelivery.Controllers
{

    [ApiController]
    [Authorize]    
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        
        [HttpGet(ApiRoutes.Product.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet(ApiRoutes.Product.Get)]
        public async Task<IActionResult> Get([FromRoute]string email, [FromRoute]int productId)
        {
            var response = await _productService.GetProductByIdAsync(productId, email);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        
        
        [HttpPost(ApiRoutes.Product.Create)]
        public async Task<IActionResult> Create([FromBody]CreateProductRequest request)
        {
            Product product = _mapper.Map<Product>(request);

            await _productService.CreateProductAsync(product);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Product.Get.Replace("{productId}", product.ProductId.ToString());

            return Created(locationUri, _mapper.Map<GetProductResponse>(product));
        }

        [HttpGet(ApiRoutes.Product.GetByName)]
        public async Task<IActionResult> GetProductsByName([FromRoute]string productName)
        {
            var products = await _productService.GetProductsByNameAsync(productName);
            return Ok(products);
        }


    }
}