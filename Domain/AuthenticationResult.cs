﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Domain
{
    public class AuthenticationResult
    {
        public string JwtToken { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }

    }
}
