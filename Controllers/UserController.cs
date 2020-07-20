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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.User.Get)]
        public async Task<IActionResult> Get([FromRoute]string email)
        {
            var user = await _userService.GetUserDetailAsync(email);

            return Ok(_mapper.Map<GetUserDetailResponse>(user));
        }
    }
}