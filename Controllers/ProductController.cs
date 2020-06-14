using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FoodDelivery.Constants;
using FoodDelivery.Database.Entities;
using FoodDelivery.DTOs.Requests;
using FoodDelivery.DTOs.Responses;
using FoodDelivery.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        [HttpGet(ApiRoutes.Product.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }

        /// <summary>
        /// Get a product by productId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet(ApiRoutes.Product.Get)]
        public async Task<IActionResult> Get([FromRoute]int productId)
        {
            var product = await _productService.GetProductByIdAsync(productId);

            if (product == null)
                return NotFound();

            return Ok(_mapper.Map<GetProductResponse>(product));
        }

        /// <summary>
        /// Create a product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Product.Create)]
        public async Task<IActionResult> Create([FromBody]CreateProductRequest request)
        {
            Product product = _mapper.Map<Product>(request);

            await _productService.CreateProductAsync(product);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Product.Get.Replace("{productId}", product.ProductId.ToString());

            return Created(locationUri, _mapper.Map<GetProductResponse>(product));
        }


    }
}