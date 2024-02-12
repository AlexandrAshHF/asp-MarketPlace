using MarketPlace.Core.Interfaces.Auth;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace MarketPlace.Application.Infrastructure
{
    public class JwtProvider : IJwtProvider
    {
        public string GenerateAuthToken(string userId, string userRole, string? sellerId)
        {
            Claim[] claims = [new("userId", userId), new("userRole", userRole)];

            if(!sellerId.IsNullOrEmpty())
                claims.Append(new Claim("sellerId", sellerId));

            return "";
        }
    }
}
