using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreWithMySql.Models.DatabaseContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace DotNetCoreWithMySql
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
            services.AddMvc();
              // //  services.AddDbContext<MyDbContext>(options =>
               //  options.UseMySql("server=localhost:8080;port=3306; user=rjporosh;password=1234;database=Test"));
            services.AddDbContextPool<MyDbContext>(
               dbContextOptions => dbContextOptions
                   .UseMySql(
                       // Replace with your connection string.
                       "server=localhost;port=3306; user=root;database=Test2",
                       // Replace with your server version and type.
                       mySqlOptions => mySqlOptions
                           .ServerVersion(new Version(8, 0, 21), ServerType.MySql)
                           .CharSetBehavior(CharSetBehavior.NeverAppend))
                   // Everything from this point on is optional but helps with debugging.
                   .UseLoggerFactory(
                       LoggerFactory.Create(
                           logging => logging
                               .AddConsole()
                               .AddFilter(level => level >= LogLevel.Information)))
                   .EnableSensitiveDataLogging()
                   .EnableDetailedErrors()
            );
          //  services.AddDbContext<MyDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
