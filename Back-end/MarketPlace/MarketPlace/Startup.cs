using MarketPlace.Application.Configurations;
using MarketPlace.Application.Services;
using MarketPlace.Core.Interfaces.Auth;
using MarketPlace.Core.Interfaces.DataIntefaces;
using MarketPlace.Core.Interfaces.Repositories;
using MarketPlace.DAL;
using MarketPlace.DAL.Repositories;
using MarketPlace.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace MarketPlace.API
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            #region My services
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<ISellerRepository, SellerRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IPlaceRepository, PlaceRepository>();

            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<ICategoryService, CategoriesService>();
            services.AddTransient<IReviewsService, ReviewsService>();

            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IJwtProvider, JwtProvider>();
            services.AddTransient<IPasswordHasher, PasswordHasher>();
            #endregion  

            services.AddControllers();
            services.AddSwaggerGen();

            #region AuthServices
            var options = new AuthOptions();
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
                       RoleClaimType = ClaimTypes.Role,
                       NameClaimType = ClaimTypes.Name,
                   };
               });

            services.AddAuthorization();
            #endregion

            string connection = _configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("DB connection string is null");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger()
                   .UseSwaggerUI(c =>
                   {
                       c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                   });

                app.UseHttpsRedirection();
                app.UseRouting();

                app.UseAuthentication();
                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller}/{action}/{id?}");
                    endpoints.MapControllerRoute(
                        name: "CatchAll",
                        pattern: "{controller}/{action}/{*data}");
                });
            }
        }
    }
}
