using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Constants;
using FoodDelivery.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    
    [ApiController]
    [Authorize]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet(ApiRoutes.Discount.Get)]
        public async Task<IActionResult> Get([FromRoute] string discountCode)
        {
            var discount = await _discountService.GetDiscountByDiscountCode(discountCode);

            if (discount == null)
                return NotFound();

            return Ok(discount);
        }
    }
}