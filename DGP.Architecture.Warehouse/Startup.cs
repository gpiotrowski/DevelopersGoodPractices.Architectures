using DGP.Architecture.Warehouse.Application.Handlers.CommandHandlers;
using DGP.Architecture.Warehouse.Common.Buses;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DGP.Architecture.Warehouse.Repositories;
using DGP.Architecture.Warehouse.Services;
using MediatR;

namespace DGP.Architecture.Warehouse
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

            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddTransient<IProductStockHistoryService, ProductStockHistoryService>();

            services.AddMediatR(typeof(BookProductHandler));
            services.AddSingleton<IMessageBus, MediatorMessageBus>();
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