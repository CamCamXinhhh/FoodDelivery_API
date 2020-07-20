using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.DTOs.Responses
{
    public class GetUserDetailResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string UserImage { get; set; }
    }
}
