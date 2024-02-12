using MarketPlace.Application.Configurations;
using MarketPlace.Core.Interfaces.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MarketPlace.API
{
    public static class ApiExtensions
    {
        public static void AddApiAuthentication(this IServiceCollection services, 
            AuthOptions options)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = true;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = options.issuer,
                        ValidateAudience = true,
                        ValidAudience = options.audience,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.key)),
                        ValidateIssuerSigningKey = true,
                    };
                });

            services.AddAuthorization();
        }
    }
}