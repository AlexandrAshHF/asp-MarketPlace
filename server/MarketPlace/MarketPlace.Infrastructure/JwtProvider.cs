﻿using MarketPlace.Application.Configurations;
using MarketPlace.Core.Interfaces.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MarketPlace.Infrastructure
{
    public class JwtProvider : IJwtProvider
    {
        private readonly AuthOptions _options = new AuthOptions();
        public string GenerateAuthToken(string userId, string userRole, string? sellerId)
        {
            Claim[] claims = [new("userId", userId), new("userRole", userRole)];

            if (!sellerId.IsNullOrEmpty())
                claims.Append(new("sellerId", sellerId));

            var signInCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.key)),
                    SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    signingCredentials: signInCredentials,
                    expires: DateTime.UtcNow.AddHours(_options.lifetime),
                    claims: claims,
                    audience: _options.audience,
                    issuer: _options.issuer);

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}
