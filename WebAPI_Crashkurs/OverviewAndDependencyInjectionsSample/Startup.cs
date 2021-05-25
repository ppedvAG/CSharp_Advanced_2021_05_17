using DependencySampleLib.GoodSample;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OverviewAndDependencyInjectionsSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Westwind.AspNetCore.LiveReload;

namespace OverviewAndDependencyInjectionsSample
{

    public class Startup
    {
        public Startup(IConfiguration configuration) //Ab hier ist die AppSettings.json bekannt. 
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) // ServiceCollection ist ein IOC-Container
        {
            services.AddLiveReload(config =>
            {
                // optional - use config instead
                //config.LiveReloadEnabled = true;
                //config.FolderToMonitor = Path.GetFullname(Path.Combine(Env.ContentRootPath,"..")) ;
            });


            services.AddControllersWithViews() //MVC ab 3.1. Verzeichnise wie Controller und Views werden benötigt, bzw muss man hinzufügen
                .AddRazorRuntimeCompilation(); //-> install-package RazorRuntimeCompilation

            //services.AddMvc(); // Vor ASP.NET Core 3.1'

            //services.AddControllers(); //WebAPI -> Controller-Verzeichnis wird benötigt. In Verbinund mit MVC, werden die WebAPI Controller in ein unterverzeichnis "api" hinzugefügt

            //services.AddRazorPages();


            //AddSingleton / AddScope / AddTransient

            //services.AddSingleton(typeof(ICar), typeof(MockCar));
            services.AddSingleton<ICar, MockCar>();

            // Jetzt wird dieses Interface verwendet. 
            services.AddSingleton<ICar, Car>(); // Singleton ist eine permante Instanz. Wird einmal aufgebaut und bleibt bestehen, solange die Application läuft. 
            
            services.AddScoped<ICar, MockCar>(); // Wird bei jedem Request neu instanziiert. 
            services.AddTransient<ICar, MockCar>(); // Wird bei jedem Request neu instanziiert. -> 


            //Einbinden von SampleWebSettings.json
            services.Configure<SampleWebSettings>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //Entwickler- oder Analysetools
                app.UseDeveloperExceptionPage(); //Logging muss zuerst erfolgen. 
                app.UseLiveReload(); // UseLiveReload
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //Allgemein
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            //Eigene Logiken (Custom Middleware) werden hier eingebunden.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
