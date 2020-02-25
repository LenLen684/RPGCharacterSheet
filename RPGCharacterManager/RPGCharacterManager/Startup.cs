using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace RPGCharacterManager
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
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
