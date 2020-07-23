using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Constants;
using FoodDelivery.DTOs.Requests;
using FoodDelivery.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    
    [ApiController]
    [Authorize]
    public class FavouriteController : ControllerBase
    {
        private readonly IFavouriteService _favouriteService;

        public FavouriteController(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }

        [HttpPost(ApiRoutes.Favourite.Create)]
        public async Task<IActionResult> Create([FromBody]CreateFavouriteRequest request)
        {
            var created = await _favouriteService.CreateFavouriteAsync(request.Email, request.ProductId);

            if (!created)
                return NoContent();

            return Ok();
            
        }

        [HttpDelete(ApiRoutes.Favourite.Delete)]
        public async Task<IActionResult> Delete([FromRoute]string email, [FromRoute]int productId)
        {
            var deleted = await _favouriteService.RemoveFavouriteAsync(email, productId);

            if (!deleted)
                return NotFound();

            return Ok();
        }

       

    }
}