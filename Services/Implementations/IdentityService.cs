using FoodDelivery.Database;
using FoodDelivery.Database.Entities;
using FoodDelivery.Domain;
using FoodDelivery.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Services.Implementations
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtSettings _jwtSettings;
        private readonly DataContext _context;

        public IdentityService(
            UserManager<User> userManager,
            JwtSettings jwtSettings,
            DataContext context
            )
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
            _context = context;
        }

        public async Task<AuthenticationResult> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            
            if (user == null)
                return new AuthenticationResult()
                {
                    Errors = new[] { "User does not exist" }
                };

            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, password);

            if (!userHasValidPassword)
            {
                return new AuthenticationResult()
                {
                    Errors = new[] { "User/Password combination is wrong" }
                };
            }

            return await GenerateAuthenticationResultForUserAsync(user);
        }

        public async Task<AuthenticationResult> RegisterAsync(string email, string password)
        {
            //Check duplicate user
            var existingUser = await _userManager.FindByEmailAsync(email);

            if(existingUser != null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User with this email already exist" }
                };
            }

            var newUser = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Email = email,
                UserName = email
            };

            var createdUser = await _userManager.CreateAsync(newUser, password);

            if (!createdUser.Succeeded)
            {
                return new AuthenticationResult()
                {
                    Errors = createdUser.Errors.Select(e => e.Description)
                };


            }
            return await GenerateAuthenticationResultForUserAsync(newUser);
        }

        private async Task<AuthenticationResult> GenerateAuthenticationResultForUserAsync(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("id", user.Id)
            };

            var userClaims = await _userManager.GetClaimsAsync(user);

            claims.AddRange(userClaims);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult()
            {
                Success = true,
                JwtToken = tokenHandler.WriteToken(token)
            };

        }
    }
}
