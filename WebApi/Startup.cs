using AutoMapper;
using BusinessLogicLayer;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.Car;
using BusinessLogicLayer.Services.CarClass;
using BusinessLogicLayer.Services.Company;
using BusinessLogicLayer.Services.Image;
using BusinessLogicLayer.Services.Order;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var mapperConfig = new MapperConfiguration(cfg => 
            {
                ConfigMapper.Init(cfg);
                MapperConfig.Init(cfg);
            });

            mapperConfig.CompileMappings();

            var mapper = new Mapper(mapperConfig);

            ConfigServices.BuildConfig(services, Configuration.GetConnectionString("DefaultConnection"));

            services.AddSingleton<IMapper>(mapperConfig.CreateMapper());

            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ICarClassService, CarClassService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IImageService, ImageService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
