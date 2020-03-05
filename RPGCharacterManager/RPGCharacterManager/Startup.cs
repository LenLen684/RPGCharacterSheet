
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;
using Microsoft.Extensions.Configuration;
using RPGCharacterManager.Models;
using RPGCharacterManager.Models.DatabaseContexts;
using RPGCharacterManager.Models.OscarsDatabaseTestingModels;

namespace RPGCharacterManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);

            //services.AddDbContext<UsersDataContext>(options =>
            //    options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            //services.BuildServiceProvider().GetService<UsersDataContext>().Database.Migrate();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "index",
                    template: "{controller=Home}/{action=Index}"
                    );
                //--Keeping these here for now to show progress--
                routes.MapRoute(
                    name: "characters",
                    template: "{controller=Home}/{action=Characters}/{UserID=000}"
                    );
                //routes.MapRoute(
                //    name: "Comeback",
                //    template: "{*.}",
                //    defaults: new { controller = "Home", action = "index" }
                //    );
            });
        }
    }
}
