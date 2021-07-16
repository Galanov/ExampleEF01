using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using efex03.Models.Scaffold;
using Microsoft.EntityFrameworkCore;
using efex03.Models.Manual;
using System.Runtime.InteropServices;

namespace efex03
{
    public class Startup
    {

        public Startup(IConfiguration config) => Configuration = config;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            string conString = getConnectionString();
            services.AddDbContext<ScaffoldContext>(options =>
                options.UseSqlServer(conString));
            services.AddDbContext<ManualContext>(options => options.UseSqlServer(conString));
        }

        private string getConnectionString()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return Configuration["ConnectionStrings:DefaultConnection"];
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return Configuration["ConnectionStrings:MacConnection"];
            }
            throw new ArgumentException();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
