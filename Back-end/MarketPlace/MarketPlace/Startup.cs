using MarketPlace.Application.Services;
using MarketPlace.Core.Interfaces.Repositories;
using MarketPlace.DAL;
using MarketPlace.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<ISellerRepository, SellerRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<ProductsService>();

            services.AddControllers();
            services.AddSwaggerGen();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o =>
            {
                
            });

            string connection = _configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("DB connection string is null");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer());
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
