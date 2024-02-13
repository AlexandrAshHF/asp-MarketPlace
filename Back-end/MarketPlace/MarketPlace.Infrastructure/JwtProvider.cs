using MarketPlace.Application.Configurations;
using MarketPlace.Core.Interfaces.Auth;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace MarketPlace.Infrastructure
{
    public class JwtProvider : IJwtProvider
    {
        private readonly AuthOptions  _options;
        public JwtProvider(AuthOptions options)
        {
            _options = options;
        }
        public string GenerateAuthToken(string userId, string userRole, string? sellerId)
        {
            Claim[] claims = [new("userId", userId), new("userRole", userRole)];

            if(!sellerId.IsNullOrEmpty())
                claims.Append(new Claim("sellerId", sellerId));

            return "";
        }
    }
}
