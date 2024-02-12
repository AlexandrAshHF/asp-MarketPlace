using MarketPlace.Application.Configurations;
using MarketPlace.Application.Infrastructure;
using MarketPlace.Application.Services;
using MarketPlace.Core.Interfaces.Auth;
using MarketPlace.Core.Interfaces.DataIntefaces;
using MarketPlace.Core.Interfaces.Repositories;
using MarketPlace.DAL;
using MarketPlace.DAL.Repositories;
using MarketPlace.Infrastructure;
using Microsoft.EntityFrameworkCore;

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
            services.Configure<AuthOptions>(_configuration.GetSection(nameof(AuthOptions)));

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<ISellerRepository, SellerRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<ICategoryService, CategoryService>();

            services.AddTransient<IJwtProvider, JwtProvider>();
            services.AddTransient<IPasswordHasher, PasswordHasher>();

            services.AddControllers();
            services.AddSwaggerGen();

            services.AddApiAuthentication(new AuthOptions());

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
