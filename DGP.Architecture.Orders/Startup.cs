using DGP.Architecture.Orders.CourierSystemAdapter;
using DGP.Architecture.Orders.Domain.ExternalSystems;
using DGP.Architecture.Orders.Domain.Repositories;
using DGP.Architecture.Orders.Domain.Services;
using DGP.Architecture.Orders.Infrastructure.Repositories;
using GDP.Architecture.Orders.WarehouseAdapter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DGP.Architecture.Orders
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<ICartRepository, CartRepository>();
            services.AddTransient<IOrdersService, OrdersService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<ICourierService, CourierService>();
            services.AddTransient<IWarehouseService, WarehouseService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
