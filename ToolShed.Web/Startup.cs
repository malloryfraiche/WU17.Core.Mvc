using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToolShed.Web.DataAccess;
using ToolShed.Web.Repositories;

namespace ToolShed.Web
{
    public class Startup
    {
        IConfiguration _configuration;
        public Startup(IConfiguration conf)
        {
            _configuration = conf;
        }
       


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var conn = _configuration.GetConnectionString("ToolShedProducts");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(conn));

            // When a component (for ex. a Controller) needs IProductRepository, an instance of FakeProductRepository will give it.
            // Called Dependency Injection.
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddMvc();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext ctx)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            // To get access to the wwwroot files...
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "pagination",
                    template: "products/page/{page}",
                    defaults: new { Controller = "Product", action = "List" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Product}/{action=List}/{id?}");
            });

            Seed.FillIfEmpty(ctx);
        }
    }
}
