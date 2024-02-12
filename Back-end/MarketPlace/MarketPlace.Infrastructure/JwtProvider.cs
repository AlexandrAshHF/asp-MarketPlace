using MarketPlace.Application.Configurations;
using MarketPlace.Core.Interfaces.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MarketPlace.Infrastructure
{
    public class JwtProvider : IJwtProvider
    {
        private readonly AuthOptions _options;
        public JwtProvider(IOptions<AuthOptions> options)
        {
            _options = options.Value;
        }
        public string GenerateAuthToken(string userId, string userRole, string? sellerId)
        {
            var signInCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.key)),
                    SecurityAlgorithms.HmacSha256);

            Claim[] claims = [new("userId", userId.ToString()),
                new("userRole", userRole)];

            if (!sellerId.IsNullOrEmpty())
                claims.Append(new Claim("sellerId", sellerId));

            var token = new JwtSecurityToken(
                    signingCredentials: signInCredentials,
                    expires: DateTime.UtcNow.AddHours(_options.lifetime),
                    claims: claims);

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}