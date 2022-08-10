using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyShop.data.Interfaces;
//using MyShop.data.Mocks;
using MyShop.data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyShop.data.DB;
using MyShop.data.Filter;

namespace MyShop
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ShopDBContext>(options => options.UseSqlite(connection));
            //services.AddDbContext<ShopDBContext>(options => options.UseSqlServer(connection));
            services.AddTransient<IBrand, BrandRepository>();
            services.AddTransient<IProduct, ProductRepository>();
            services.AddTransient<IAssembly, AssemblyRepository>();
            services.AddTransient<IColor, ColorRepository>();
            services.AddTransient<IImage, ImageRepository>();
            services.AddTransient<IProperty, PropertyRepository>();
            services.AddTransient<ICategory_property, Category_propertyRepository>();
            services.AddTransient<IÑharacteristicsFilter, ÑharacteristicsFilter>();
            //services.AddTransient<IÑharacteristicsFilter, MockÑharacteristicsFilter>();
            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();
            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Shop}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
