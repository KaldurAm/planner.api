using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Planner.BLL.Interfaces;
using Planner.DAL.Tables;
using Planner.Shared.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Planner.BLL.Services.Auth
{
    public class ClaimService : IClaimService
    {
        private readonly IConfiguration _configuration;

        public ClaimService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<UserManagerResponse> GetClaims(ApplicationUser user, params string[] roles)
        {
            var claims = new List<Claim>
            {
                new Claim("Email", user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var signingCredentials = GetSigningCredentials();

            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new UserManagerResponse(token: tokenString, success: true, expiredDate: tokenOptions.ValidTo);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]);

            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, IEnumerable<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
               issuer: _configuration["AuthSettings:Issuer"],
               audience: _configuration["AuthSettings:Audience"],
               claims: claims,
               expires: DateTime.Now.AddDays(1).AddMinutes(Convert.ToDouble(_configuration["AuthSettings:ExpiryInMinutes"])),
               signingCredentials: signingCredentials);

            return tokenOptions;
        }
    }
}
